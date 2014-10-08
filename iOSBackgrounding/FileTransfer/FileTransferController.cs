using System;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading.Tasks;

namespace FileTransfer
{
	public partial class FileTransferController : UITableViewController
	{
		public FileTransferController (IntPtr handle) : base (handle)
		{
		}

		/// <summary>
		/// Every session needs a unique identifier.
		/// </summary>
		const string SessionId = "com.xamarin.filetransfersession";

		/// <summary>
		/// Our session used for transfer.
		/// </summary>
		public NSUrlSession Session {
			get;
			set;
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			this.Title = "Downloads";

			// Add a bar button item to exit the app manually. Don't do this in productive apps - Apple won't approve it!
			// We have it here to demonstrate that iOS will relaunch the app if a download has finished.
			this.NavigationItem.LeftBarButtonItem = new UIBarButtonItem ("Quit", UIBarButtonItemStyle.Plain, delegate {
				// Store all download info to disk. If iOS terminates the app, this would be handled in WillTerminate().
				// However this won't be triggered if the app is killed manually by this call.
				AppDelegate.SerializeAvailableDownloads();

				// Exit application with code 3.
				FileTransferController.Exit(3);
			});


			// Add a bar button item to reset all downloads.
			var refreshBtn = new UIBarButtonItem (UIBarButtonSystemItem.Refresh);
			refreshBtn.Clicked += async (sender, e) => {
				var pendingTasks = await this.Session.GetTasksAsync();
				if(pendingTasks != null && pendingTasks.DownloadTasks != null)
				{
					foreach(var task in pendingTasks.DownloadTasks)
					{
						task.Cancel();
					}
				}

				AppDelegate.AvailableDownloads.ForEach(info => {
					if(info.DestinationFile != null)
					{
						try
						{
							File.Delete(info.DestinationFile.Path);
						}
						catch(Exception ex)
						{
							Console.WriteLine("Failed to delete '{0}': {1}", info.DestinationFile, ex);
						}
					}

					info.Reset();
					info.Status = DownloadInfo.STATUS.Idle;
				});

				AppDelegate.ResetAvailableDownloads();
				((DelegateTableViewSource<DownloadInfo>)(this.TableView.Source)).Items = AppDelegate.AvailableDownloads;

				this.TableView.ReloadData();

				AppDelegate.SerializeAvailableDownloads();
			};
			this.NavigationItem.RightBarButtonItem = refreshBtn;
			

			// TODO: FileTransfer 01 - Create a session
			// Initialize our session config. We use a background session to enabled out of process uploads/downloads. Note that there are other configurations available:
			// - DefaultSessionConfiguration: behaves like NSUrlConnection. Used if *background* transfer is not required.
			// - EphemeralSessionConfiguration: use if you want to achieve something like private browsing where all sesion info (e.g. cookies) is kept in memory only.
			using (var sessionConfig = UIDevice.CurrentDevice.CheckSystemVersion(8, 0) ? NSUrlSessionConfiguration.CreateBackgroundSessionConfiguration(SessionId) : NSUrlSessionConfiguration.BackgroundSessionConfiguration (SessionId))
			{
				// Allow downloads over cellular network too.
				sessionConfig.AllowsCellularAccess = true;

				// We want our app to be launched if required.
				sessionConfig.SessionSendsLaunchEvents = true;

				// Give the OS a hint about what we are downloading. This helps iOS to prioritize. For example "Background" is used to download data that was not requested by the user and
				// should be ready if the app gets activated.
				sessionConfig.NetworkServiceType = NSUrlRequestNetworkServiceType.Default;

				// Configure how many downloads we allow at the same time. Set to 2 to see that further downloads start once the first two have been completed.
				sessionConfig.HttpMaximumConnectionsPerHost = 2;

				// TODO: FileTransfer 02 - Create a session delegate and the session itself
				// Initialize the session itself with the configuration and a session delegate.
				var sessionDelegate = new SessionDelegate (this);
				this.Session = NSUrlSession.FromConfiguration (sessionConfig, sessionDelegate, null);
			}

			// Create a source for the table view.
			var source = new DelegateTableViewSource<DownloadInfo> (this.TableView, "downloaderCellId")
			{
				Items = AppDelegate.AvailableDownloads,
				GetCellFunc = (info, cell) =>
				{
					var downloaderCell = (DownloaderCell)cell;
					downloaderCell.UpdateFromDownloadInfo(info);
					return downloaderCell;
				},
				RowSelectedFunc = info =>
				{
					if(info.Status == DownloadInfo.STATUS.Completed)
					{
						var previewController = UIDocumentInteractionController.FromUrl(info.DestinationFile);
						previewController.Delegate = new PreviewDelegate(this);
						previewController.PresentPreview(true);
					}
				}
			};

			this.TableView.RowHeight = 55;
			this.TableView.Source = source;

			// Trigger a delegate if the user taps a button of a cell.
			DownloaderCell.ActionRequested = this.HandleActionRequested;
		}

		/// <summary>
		/// Gets triggered if one of the buttons of a cell in the table view was touched.
		/// </summary>
		/// <param name="cell">Cell.</param>
		/// <param name="button">Button.</param>
		/// <param name="action">Action.</param>
		async void HandleActionRequested(DownloaderCell cell, UIButton button, DownloaderCell.TRANSFER_ACTION action)
		{
			// Get the index of the cell in the table view.
			var path = this.TableView.IndexPathForCell (cell);
			if (path == null)
			{
				return;
			}
			int index = path.Row;

			// Get the related download info object.
			var downloadInfo = AppDelegate.AvailableDownloads[index];

			// Via the task identifier we can get back to the enqueued task.
			var pendingTasks = await this.Session.GetTasksAsync ();
			NSUrlSessionDownloadTask downloadTask = pendingTasks.DownloadTasks.FirstOrDefault (t => t.TaskIdentifier == downloadInfo.TaskId);

			switch(action)
			{
			case DownloaderCell.TRANSFER_ACTION.Download:
				Console.WriteLine ("Creating new download task.");
				// Create a new download task.
				downloadTask = this.Session.CreateDownloadTask (NSUrl.FromString (downloadInfo.Source));

				// The creation can fail. 
				if (downloadTask == null)
				{
					new UIAlertView (string.Empty, "Failed to create download task! Please retry.", null, "OK").Show ();
					return;
				}

				// Update the download info object.
				downloadInfo.TaskId = (int)downloadTask.TaskIdentifier;
				downloadInfo.Status = DownloadInfo.STATUS.Downloading;

				// Resume / start the download.
				downloadTask.Resume ();
				Console.WriteLine ("Starting download of '{0}'. State of task: '{1}'. ID: '{2}'", downloadInfo.Title, downloadTask.State, downloadTask.TaskIdentifier);

				/*
				// If this code is commented in, the app will exit immediately after the downlaod has been initiated.
				// When the download completes, iOS will relaunch the app and the UI will reflect the current state.
				AppDelegate.SerializeAvailableDownloads ();
				Exit (3);
				*/

				break;

			case DownloaderCell.TRANSFER_ACTION.Stop:
				if (downloadTask != null)
				{
					downloadTask.Cancel ();
				}
				downloadInfo.Reset ();
				downloadInfo.Status = DownloadInfo.STATUS.Cancelled;
				Console.WriteLine ("Stopping download of '{0}'.", downloadInfo.Title);
				break;

			case DownloaderCell.TRANSFER_ACTION.View:
				break;
			}

			// Update UI.
			cell.UpdateFromDownloadInfo (downloadInfo);
		}

		/// <summary>
		/// Import private API to allow exiting app manually.
		/// For demo purposes only! Do not use this in productive apps!
		/// </summary>
		/// <param name="status">Status.</param>
		[DllImport("__Internal", EntryPoint = "exit")]
		public static extern void Exit(int status);
	}
}
