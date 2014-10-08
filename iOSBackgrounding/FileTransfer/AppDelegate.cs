using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FileTransfer
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		/// <summary>
		/// Path and filename of serialized info about possible downloads.
		/// </summary>
		public static string DownloadInfoFileLocation = Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments), "serialized.dat");

		/// <summary>
		/// Prepare some files for download.
		/// </summary>
		public static List<DownloadInfo> AvailableDownloads = null;

		/// <summary>
		/// Resets the available downloads.
		/// </summary>
		public static void ResetAvailableDownloads()
		{
			AvailableDownloads = new List<DownloadInfo> {
				// Can be used in case internet is down. Open Terminal in the solution's folder and bring up a Python web server:
				// python /System/Library/Frameworks/Python.framework/Versions/2.7/lib/python2.7/SimpleHTTPServer.py
				//new DownloadInfo { Title = "Test", Source  = "http://0.0.0.0:8000/test.pdf" },
				//new DownloadInfo { Title = "iOS Programming Guide", Source  = "https://developer.apple.com/library/ios/documentation/iphone/conceptual/iphoneosprogrammingguide/iphoneappprogrammingguide.pdf" },

				// The following files are served from Apple servers. Use if internet is up.
				new DownloadInfo { Title = "Networking Overview", Source  = "https://developer.apple.com/library/ios/documentation/NetworkingInternetWeb/Conceptual/NetworkingOverview/NetworkingOverview.pdf" },
				new DownloadInfo { Title = "AV Foundation", Source  = "https://developer.apple.com/library/ios/documentation/AudioVideo/Conceptual/AVFoundationPG/AVFoundationPG.pdf" },
				new DownloadInfo { Title = "iPhone User Guide", Source  = "http://manuals.info.apple.com/MANUALS/1000/MA1565/en_US/iphone_user_guide.pdf" },
			};
		}

		/// <summary>
		/// Serializes available downloads.
		/// </summary>
		public static void SerializeAvailableDownloads()
		{
			Console.WriteLine ("Serializing available downloads.");
			using(Stream stream = File.Open(DownloadInfoFileLocation, FileMode.Create))
			{
				var formatter = new BinaryFormatter();

				formatter.Serialize(stream, AvailableDownloads);
			}
		}

		/// <summary>
		/// Helper to find a DownloadInfo object via its task identifier.
		/// </summary>
		/// <returns>The download info by task identifier.</returns>
		/// <param name="taskId">Task identifier.</param>
		public static DownloadInfo GetDownloadInfoByTaskId(uint taskId)
		{
			return AvailableDownloads.FirstOrDefault (x => x.TaskId == taskId);
		}

		/// <summary>
		/// Helper to find a DownloadInfo object via its task identifier.
		/// </summary>
		/// <returns>The download info by task identifier.</returns>
		/// <param name="taskId">Task identifier.</param>
		public static int GetDownloadInfoIndexByTaskId(uint taskId)
		{
			return AvailableDownloads.FindIndex (x => x.TaskId == taskId);
		}

		public override UIWindow Window {
			get;
			set;
		}

		public override void FinishedLaunching (UIApplication application)
		{
			Console.WriteLine ("FinishedLaunching()");
		}

		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			Console.WriteLine ("FinishedLaunching() - with options");

			// For iOS8 we must get permission to show local notifications.
			if (UIDevice.CurrentDevice.CheckSystemVersion (8, 0))
			{
				var settings = UIUserNotificationSettings.GetSettingsForTypes (UIUserNotificationType.Alert, new NSSet ());
				if (UIApplication.SharedApplication.CurrentUserNotificationSettings != settings)
				{
					UIApplication.SharedApplication.RegisterUserNotificationSettings (settings);
				}
			}

			// Try to deserialize existing download information. If there isn't any, create a new set.
			if (File.Exists (DownloadInfoFileLocation))
			{
				Console.WriteLine ("Deserializing existing download data.");
				try
				{
					using (var stream = File.Open (DownloadInfoFileLocation, FileMode.Open))
					{
						var formatter = new BinaryFormatter ();
						AppDelegate.AvailableDownloads = (List<DownloadInfo>)formatter.Deserialize (stream);
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine ("Failed to deserialize download data: " + ex);
				}
			}
			else
			{
				Console.WriteLine ("No serialized download info found. Creating new.");
				ResetAvailableDownloads ();
			}

			return true;
		}

		// This method is invoked when the application is about to move from active to inactive state.
		// OpenGL applications should use this method to pause.
		public override void OnResignActivation (UIApplication application)
		{
			Console.WriteLine ("OnResignActivation()");
		}
		
		// This method should be used to release shared resources and it should store the application state.
		// If your application supports background exection this method is called instead of WillTerminate
		// when the user quits.
		public override void DidEnterBackground (UIApplication application)
		{
			Console.WriteLine ("DidEnterBackground()");
		}
		
		// This method is called as part of the transiton from background to active state.
		public override void WillEnterForeground (UIApplication application)
		{
			Console.WriteLine ("WillEnterForeground()");
		}

		
		// This method is called when the application is about to terminate. Save data, if needed.
		public override void WillTerminate (UIApplication application)
		{
			Console.WriteLine ("WillTerminate()");
			// App is getting terminated. Store all download info to disk so we can resume later.
			SerializeAvailableDownloads ();
		}

		/// <summary>
		/// We have to call this if our transfer (of all files!) is done.
		/// </summary>
		public static NSAction BackgroundSessionCompletionHandler
		{
			get;
			set;
		}

		// TODO: FileTransfer 00 - Handle if app gets launched into background
		/// <summary>
		/// Gets called by iOS if we are required to handle something regarding our background downloads.
		/// </summary>
		public override void HandleEventsForBackgroundUrl (UIApplication application, string sessionIdentifier, NSAction completionHandler)
		{
			// We get a completion handler which we are supposed to call if our transfer is done.
			BackgroundSessionCompletionHandler = completionHandler;
		}
	}
}

