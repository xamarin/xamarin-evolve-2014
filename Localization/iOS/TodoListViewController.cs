using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace LionTodo
{
	public class TodoListViewController : UITableViewController
	{
		UIBarButtonItem addButton;

		public TodoListViewController ()
		{
			// TODO: iOS use the native method here
			Title = NSBundle.MainBundle.LocalizedString ("LionTodo", "LionTodo");
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			addButton = new UIBarButtonItem(UIBarButtonSystemItem.Add, (s,e) =>{
				var todo = new Todo() {
					// TODO: iOS localize the placeholder text
					Title= Lion.Localize("<new task>", "<new task>") 
				};

				AppDelegate.Current.TodoDB.Save (todo);

				var todoView = new TodoViewController(todo);
				NavigationController.PushViewController (todoView, true);
			});
			NavigationItem.RightBarButtonItem = addButton;

		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			TableView.Source = new TodoTableSource (AppDelegate.Current.TodoDB.GetAll (), this);
		}
	}
}

