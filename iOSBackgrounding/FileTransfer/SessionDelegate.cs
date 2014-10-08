using System;
using MonoTouch.Foundation;
using System.IO;
using MonoTouch.UIKit;

namespace FileTransfer
{
	// TODO: FileTransfer 03 - Session Delegate
	/// <summary>
	/// Delegate used to control file transfers. Note that there is also NSUrlSessionUploadDelegate fif you want to do uploads.
	/// </summary>
	public class SessionDelegate : NSUrlSessionDownloadDelegate
	{
		public SessionDelegate (FileTransferController controller) : base()
		{
			this.controller = controller;
		}

		FileTransferController controller;

		/// <summary>
		/// Gets called as we receive data.
		/// </summary>
		/// <param name="session">Session.</param>
		/// <param name="downloadTask">Download task.</param>
		/// <param name="totalBytesWritten">Total bytes written.</param>
		public override void DidWriteData (NSUrlSession session, NSUrlSessionDownloadTask downloadTask, long bytesWritten, long totalBytesWritten, long totalBytesExpectedToWrite)
		{
			uint localIdentifier = downloadTask.TaskIdentifier;
			Console.WriteLine ("DidWriteData - Task: {0}, BytesWritten: {1}, Total: {2}, Expected: {3}", localIdentifier, bytesWritten, totalBytesWritten, totalBytesExpectedToWrite);

			var downloadInfo = AppDelegate.GetDownloadInfoByTaskId (localIdentifier);
			int index = AppDelegate.GetDownloadInfoIndexByTaskId (localIdentifier);

			if (downloadInfo != null)
			{
				downloadInfo.Progress = (float)totalBytesWritten / (float)totalBytesExpectedToWrite;
			}
			else
			{
				Console.WriteLine ("Unable to find download info for task ID '{0}'.", localIdentifier);
			}

			// We are not on the UI thread here.
			var indexPath = NSIndexPath.FromRowSection (index, 0);
			this.InvokeOnMainThread (() =>
			{
				this.controller.TableView.ReloadRows (new NSIndexPath[] { indexPath }, UITableViewRowAnimation.None);
			});
		}

		/// <summary>
		/// Gets called if the download has been completed.
		/// </summary>
		public override void DidFinishDownloading (NSUrlSession session, NSUrlSessionDownloadTask downloadTask, NSUrl location)
		{
			// The download location will be a file location.
			var sourceFile = location.Path;


			// Construct a destination file name.
			var destFile = downloadTask.OriginalRequest.Url.AbsoluteString.Substring(downloadTask.OriginalRequest.Url.AbsoluteString.LastIndexOf("/") + 1);

			Console.WriteLine ("DidFinishDownloading - Task: {0}, Source file: {1}", downloadTask.TaskIdentifier, sourceFile);

			// Copy over to documents folder. Note that we must use NSFileManager here! File.Copy() will not be able to access the source location.
			NSFileManager fileManager = NSFileManager.DefaultManager;

			// Create the filename
			var documentsFolderPath = Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments);
			NSUrl destinationURL = NSUrl.FromFilename(Path.Combine(documentsFolderPath, destFile));

			// Update download info object.
			var downloadInfo = AppDelegate.GetDownloadInfoByTaskId (downloadTask.TaskIdentifier);

			// Remove any existing file in our destination
			NSError error;
			fileManager.Remove(destinationURL, out error);
			bool success = fileManager.Copy(sourceFile, destinationURL.Path, out error);
			if (success)
			{
				location = destinationURL;
				this.UpdateDownloadInfo (downloadInfo, DownloadInfo.STATUS.Completed, destinationURL);
			} else
			{
				this.UpdateDownloadInfo (downloadInfo, DownloadInfo.STATUS.Cancelled, null);
				Console.WriteLine ("Error during the copy: {0}", error.LocalizedDescription);
			}

			this.InvokeOnMainThread (() => this.controller.TableView.ReloadData());
		}

		/// <summary>
		/// Very misleading method name. Gets called if a download is done. Does not necessarily indicate an error
		/// unless the NSError parameter is not null.
		/// </summary>
		public override void DidCompleteWithError (NSUrlSession session, NSUrlSessionTask task, NSError error)
		{
			if (error == null)
			{
				return;
			}

			Console.WriteLine ("DidCompleteWithError - Task: {0}, Error: {1}", task.TaskIdentifier, error);
			var downloadInfo = AppDelegate.GetDownloadInfoByTaskId (task.TaskIdentifier);
			if (downloadInfo != null)
			{
				downloadInfo.Reset ();
			}

			task.Cancel ();
			this.InvokeOnMainThread (() => this.controller.TableView.ReloadData());
		}

		/// <summary>
		/// Gets called by iOS if all pending transfers are done. 
		/// </summary>
		public override void DidFinishEventsForBackgroundSession (NSUrlSession session)
		{
			// Nothing more to be done. This is the place where we have to call the completion handler we get passed in in AppDelegate.
			var handler = AppDelegate.BackgroundSessionCompletionHandler;
			AppDelegate.BackgroundSessionCompletionHandler = null;
			if (handler != null)
			{
				Console.WriteLine ("Calling completion handler.");
				NSOperationQueue.MainQueue.AddOperation(() =>
				{
					this.controller.TableView.ReloadData();

					new UIAlertView(string.Empty, "Selected files have been downloaded.", null, "OK").Show();

					// Bring up a local notification to take the user back to our app.
					Console.WriteLine ("Posting notification.");
					var notif = new UILocalNotification { 
						AlertBody = "Xamarin news: All pending files have been downloaded!"
					};
					UIApplication.SharedApplication.PresentLocationNotificationNow (notif);

					// Invoke the completion handle. This will tell iOS to update the snapshot in the task manager.
					handler.Invoke ();
				});
			}
		}

		void UpdateDownloadInfo(DownloadInfo downloadInfo, DownloadInfo.STATUS status, NSUrl destinationUrl)
		{
			// Update download info object.
			downloadInfo.Reset ();

			downloadInfo.Status = status;
			downloadInfo.DestinationFile = destinationUrl;
		}
	}
}

