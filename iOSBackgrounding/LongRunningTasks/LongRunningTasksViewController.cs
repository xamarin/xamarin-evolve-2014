using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Threading.Tasks;
using System.Threading;

namespace LongRunningTasks
{
	public partial class LongRunningTasksViewController : UIViewController
	{
		public LongRunningTasksViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			this.cts = new CancellationTokenSource ();
		}

		bool isCalculating;
		CancellationTokenSource cts;

		/// <summary>
		/// Gets called when pressing the button to calculate PI.
		/// </summary>
		/// <param name="sender">Sender.</param>
		partial void HandleCalculatePi (UIButton sender)
		{
			this.isCalculating = !this.isCalculating;
			btnCalculate.SetTitle(this.isCalculating ? "Stop calculating" : "Start calculating", UIControlState.Normal);

			if(!this.isCalculating)
			{
				// Cancel calculation if it is currently running.
				this.cts.Cancel();
				return;
			}
			else
			{
				// Use a cancellation token to be able to stop the calculation.
				this.cts = new CancellationTokenSource();
				this.txtPi.Text = string.Empty;
			}

			// Prepare for background processing.
			int taskId = -1;

			// We are running on an extra thread here. Still, the app gets paused if it is backgrounded.
			Task.Run(() =>
			{
				// TODO: LongRunningTasks 01 - Comment back in to prevent thread from being interrupted if home button is pressed
//				taskId = UIApplication.SharedApplication.BeginBackgroundTask(() => {
//					Console.WriteLine("Background time expires!");
//					this.cts.Cancel();
//				});

				Helpers.CalcPi(pi => 
				{
					Console.WriteLine("Background time remaining: " + Math.Round(UIApplication.SharedApplication.BackgroundTimeRemaining) + " seconds");
					Console.WriteLine("A bit of Pi: " + pi);
					this.InvokeOnMainThread(() => 
					{
						this.txtPi.Text += " " + pi;
						var range = new NSRange(txtPi.Text.Length - 1, 1);
						txtPi.ScrollRangeToVisible(range);
					});
				}, this.cts.Token);

				if(taskId != -1)
				{
					// Balanced call to BeginBackgroundTask()
					UIApplication.SharedApplication.EndBackgroundTask(taskId);
				}
			});
		}
	}
}

