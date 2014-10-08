using System;
using MonoTouch.Foundation;
using System.IO;

namespace FileTransfer
{
	/// <summary>
	/// Contains status information about the current downloads.
	/// </summary>
	[Serializable]
	public sealed class DownloadInfo
	{
		public enum STATUS
		{
			Idle,
			Downloading,
			Cancelled,
			Completed
		}

		public DownloadInfo ()
		{
			this.Progress = -1;
			this.TaskId = -1;
			this.Status = STATUS.Idle;
		}

		public void Reset()
		{
			this.Progress = -1.0f;
			this.Status = DownloadInfo.STATUS.Idle;
			this.TaskId = -1;

			if(this.DestinationFile != null)
			{
				string filename = string.Empty;
				try
				{
					filename = this.DestinationFile.Path;

					File.Delete (filename);
				}
				catch(Exception ex)
				{
					Console.WriteLine("Failed to delete '{0}': {1}", this.DestinationFile, ex);
				}
			}
			this.DestinationFile = null;
		}

		/// <summary>
		/// Title shown during download.
		/// </summary>
		/// <value>The title.</value>
		public string Title
		{
			get;
			set;
		}

		/// <summary>
		/// Where the file is downloaded from.
		/// </summary>
		public string Source
		{
			get;
			set;
		}

		/// <summary>
		/// Download progress.
		/// </summary>
		public float Progress {
			get;
			set;
		}

		/// <summary>
		/// NSUrlSession gives as unique Task IDs.
		/// </summary>
		public int TaskId
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the status.
		/// </summary>
		public STATUS Status {
			get;
			set;
		}

		/// <summary>
		/// The location of the downloaded file on disk.
		/// </summary>
		public NSUrl DestinationFile
		{
			get
			{ 
				return this.destinationFile != null ? NSUrl.FromString (this.destinationFile) : null;
			}
			set
			{ 
				this.destinationFile = value != null ? value.AbsoluteString : null;
			}
		}
		string destinationFile;

		public override string ToString ()
		{
			return string.Format ("[DownloadInfo: Title={0}, Source={1}, Progress={2}, TaskId={3}, Status={4}, DestinationFile={5}]", Title, Source, Progress, TaskId, Status, DestinationFile);
		}
	}
}

