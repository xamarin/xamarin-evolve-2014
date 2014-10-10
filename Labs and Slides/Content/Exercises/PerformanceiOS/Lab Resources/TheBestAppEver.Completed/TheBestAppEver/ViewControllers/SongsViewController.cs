using System;
using MonoTouch.UIKit;

namespace TheBestAppEver
{
	public class SongsViewController : UITableViewController
	{
		SongsViewModel viewModel;
		UIProgressView progressView;

		// TODO: Step 2a
		DateTime lastUpdate;

		public SongsViewController ()
		{
			Title = "Songs";
			TableView.Source = new ViewModelDataSource<Song> {
				CellForItem = (tv,item) => {
					var cell = tv.DequeueReusableCell<SongCell>(SongCell.Key);
					cell.Song = item;
					return cell;
				},
				ViewModel = (viewModel = new SongsViewModel()),
			};

			TableView.TableHeaderView = progressView = new UIProgressView (UIProgressViewStyle.Bar) {
				Alpha = 0f
			};

			progressView.SizeToFit ();

			viewModel.ItemsChanged += (sender, e) => {
				// TODO: Step 2b - update UI 1/sec vs. each notification
				if ((DateTime.Now - lastUpdate).TotalSeconds >= 1) {
					InvokeOnMainThread(() => {
						Console.WriteLine("Reloading the TableView.");
						TableView.ReloadData();
					});
					lastUpdate = DateTime.Now;
				}
			};

			viewModel.SongsUpdated += progress => 
				InvokeOnMainThread(() => {
					Console.WriteLine("{0:P}", progress);
					progressView.Progress = progress;
					progressView.Alpha = progress >= 1f ? 0 : 1;
				});

		}

		public async override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			await viewModel.Refresh();
		}
	}
}

