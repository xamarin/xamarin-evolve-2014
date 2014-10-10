using System;
using MonoTouch.UIKit;

namespace TheBestAppEver
{
	public class TodoViewController : UITableViewController
	{	
		TodoViewModel viewModel;
		ViewModelDataSource<TodoItem> DataSource;
		public TodoViewController ()
		{
			Title = "Todo Items";
			TableView.Source = DataSource = new ViewModelDataSource<TodoItem>{
				CellForItem = (tv,item)=>{
					var cell = tv.DequeueReusableCell<TodoItemCell>(TodoItemCell.Key);
					cell.Item = item;
					return cell;
				},
				ViewModel = (viewModel = new TodoViewModel()),
			};

			viewModel.ItemsChanged += (sender, e) => TableView.ReloadData();
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			this.RefreshControl = new UIRefreshControl();
			RefreshControl.ValueChanged += async (sender, e) => 
			{
				await viewModel.Refresh();
				InvokeOnMainThread(RefreshControl.EndRefreshing);
			};
		}

		public async override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			await viewModel.Refresh ();
		}
	}
}

