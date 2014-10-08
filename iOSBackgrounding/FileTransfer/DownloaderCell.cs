using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace FileTransfer
{
	/// <summary>
	/// Represents one cell for the table view in the UI.
	/// </summary>
	partial class DownloaderCell : UITableViewCell
	{
		public DownloaderCell (IntPtr handle) : base (handle)
		{
		}

		/// <summary>>
		/// Possible actions to trigger from a cell.
		/// </summary>
		public enum TRANSFER_ACTION
		{
			/// <summary>
			/// View the downloaded file.
			/// </summary>
			View,
			/// <summary>
			/// Start downloading the file or continue.
			/// </summary>
			Download,
			/// <summary>
			/// Cancel the download.
			/// </summary>
			Stop
		}

		/// <summary>
		/// Provide a static delegate that gets triggered if a button was pressed in a cell.
		/// </summary>
		public static Action<DownloaderCell, UIButton, TRANSFER_ACTION> ActionRequested = delegate
		{
		};

		/// <summary>
		/// Updates the cell's UI from a DownloadInfo object.
		/// </summary>
		/// <param name="info">Info.</param>
		public void UpdateFromDownloadInfo(DownloadInfo info)
		{
			bool showDownload = info.Status != DownloadInfo.STATUS.Downloading && info.Status != DownloadInfo.STATUS.Completed;
			bool showStop = info.Status == DownloadInfo.STATUS.Downloading;
			bool showProgress = info.Status == DownloadInfo.STATUS.Downloading;
		
			this.btnDownload.Hidden = !showDownload;
			this.btnStop.Hidden = !showStop;
			this.progressView.Hidden = !showProgress;

			this.progressView.Progress = info.Progress;

			this.lblFilename.TextColor = info.Status == DownloadInfo.STATUS.Completed ? UIColor.Green : UIColor.Black;

			this.lblFilename.Text = info.Title;
		}

		/// <summary>
		/// Gets called if the download button of the cell was tapped.
		/// </summary>
		/// <param name="sender">Sender.</param>
		partial void HandleStartDownload (UIButton sender)
		{
			// Trigger a delegate.
			ActionRequested(this, sender, TRANSFER_ACTION.Download);
		}

		/// <summary>
		/// Gets called if the stop button of the cell was tapped.
		/// </summary>
		/// <param name="sender">Sender.</param>
		partial void HandleStopDownload (UIButton sender)
		{
			// Trigger a delegate.
			ActionRequested(this, sender, TRANSFER_ACTION.Stop);
		}
	}
}
