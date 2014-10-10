using System;
using MonoTouch.UIKit;
using System.Threading.Tasks;
using System.Threading;
using System.Text;
using MonoTouch.Foundation;

namespace Demo2LongRunningTasks
{
	partial class LongRunningTaskViewController : UIViewController
	{
        #region Constants and Private Data
        const string StartText = "Start Long Running Task";
        const string CancelText = "Cancel Running Task";
        readonly UIColor StartColor = UIColor.FromRGB(0, 120, 0);
        readonly UIColor StopColor = UIColor.FromRGB(120, 0, 0);
        const long MaxTextLength = 4096;

        StringBuilder logText = new StringBuilder();
        int taskId;
        volatile bool running;
        #endregion

        public LongRunningTaskViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            TaskLogText.Text = string.Empty;
            TaskButton.BackgroundColor = StartColor;
        }

        async partial void OnStartTask(UIButton sender)
        {
            // Stop the task if it's running.
            if (taskId > 0) {
                LogText("Stopping Task...");
                running = false;
                return;
            }

            sender.SetTitle(CancelText, UIControlState.Normal);
            TaskButton.BackgroundColor = StopColor;
            running = true;

            taskId = 1;

            // TODO: Demo2 - Step 1a - Register background task
//			taskId = UIApplication.SharedApplication.BeginBackgroundTask(() => {});

            // TODO: Demo2 - Step 2a - add cancellation support
            var cts = new CancellationTokenSource();
            taskId = UIApplication.SharedApplication.BeginBackgroundTask("Long-Running Task", () => {
                LogText("Task {0} timeout occurred, canceled.", taskId);
                cts.Cancel();
            });

            // Kick off .NET Task to run in the background.
            try {
                await Task.Run(() => {
                    for (long count = 1; running == true ; count++) {

                        this.BeginInvokeOnMainThread(() => {
                            LogText("Task {0} running.. {1}", taskId, count);
                        });

                        // TODO: Demo2 - Step 2b - add cancellation support
                        cts.Token.ThrowIfCancellationRequested();
                        Thread.Sleep(1000);
                    }
                // TODO: Demo2 - Step 2c - add cancellation support 
                }, cts.Token);
            }
            catch (OperationCanceledException)
            {
                LogText("Task {0} was cancelled.", taskId);
            }
            catch (Exception ex)
            {
                LogText("Exception: {0}", ex.Message);
            }
            finally
            {
                // TODO: Demo2 - Step 1b - End the background task
                UIApplication.SharedApplication.EndBackgroundTask(taskId);
                sender.SetTitle(StartText, UIControlState.Normal);
                TaskButton.BackgroundColor = StartColor;
                taskId = 0;
                running = false;
            }
        }

        void LogText(string format, params object[] args)
        {
            var text = string.Format(format, args);

            Console.WriteLine(text);

            if (logText.Length + text.Length > MaxTextLength)
                logText.Clear();

            // Add the line into the UI and scroll the TextView to the bottom.
            logText.AppendLine(text);
            TaskLogText.Text = logText.ToString();
            TaskLogText.ScrollRangeToVisible(new NSRange(logText.Length, 0));
            TaskLogText.ScrollEnabled = false;
            TaskLogText.ScrollEnabled = true;
        }
    }	
}
