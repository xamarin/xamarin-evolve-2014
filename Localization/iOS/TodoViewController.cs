using System;
using MonoTouch.UIKit;
using System.Drawing;
using MonoTouch.Foundation;

namespace LionTodo
{
	public class TodoViewController : UIViewController
	{
		public TodoViewController (Todo todo)
		{
			currentTodo = todo;
			//TODO: iOS we use the native method here (just as an example)
			Title = NSBundle.MainBundle.LocalizedString ("Task Details", "Task Details");
		}

		UIButton saveButton, deleteButton;
		UILabel doneLabel, nameLabel, notesLabel;
		UISwitch doneSwitch;
		UITextView notesText, nameText;

		public Todo currentTodo { get; set; }

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			#region UI Controls (you could do this in XIB if you want)
			View.BackgroundColor = UIColor.White;

			int y = 60; // iOS7

			nameLabel = new UILabel();
			nameLabel.Frame = new RectangleF(10, y + 10, 145, 15);

			nameText = new UITextView(new RectangleF(10, y + 30, 300, 40));
			nameText.BackgroundColor = UIColor.FromRGB(240,240,240);
			nameText.Editable = true;
			nameText.Font = UIFont.SystemFontOfSize(20);

			notesLabel = new UILabel();
			notesLabel.Frame = new RectangleF(10, y + 75, 145, 15);

			notesText = new UITextView(new RectangleF(10, y + 95, 300, 40));
			notesText.BackgroundColor = UIColor.FromRGB(240,240,240);
			notesText.Editable = true;
			notesText.ScrollEnabled = true;
			notesText.AutoresizingMask = UIViewAutoresizing.FlexibleHeight;

			doneLabel = new UILabel();
			doneLabel.Frame = new RectangleF(10, y + 145, 80, 15);
			doneSwitch = new UISwitch();
			doneSwitch.Frame = new RectangleF(90, y + 140, 145, 50);


			saveButton = UIButton.FromType(UIButtonType.RoundedRect);
			saveButton.Frame = new RectangleF(10,y + 170,145,40);

			deleteButton = UIButton.FromType(UIButtonType.RoundedRect);
			deleteButton.Frame = new RectangleF(155,y + 170,145,40);

			// Add the controls to the view
			this.Add(saveButton);
			this.Add(deleteButton);
			this.Add(doneLabel);
			this.Add(doneSwitch);
			this.Add(notesText );
			this.Add(nameText);
			this.Add(notesLabel);
			this.Add(nameLabel);
			#endregion

			// TODO: iOS ALL (most) localizations happen here!
			nameLabel.Text = Lion.Localize("Name", "Name");
			notesLabel.Text = Lion.Localize("Notes", "Notes");
			doneLabel.Text = Lion.Localize("Done", "Done");
			saveButton.SetTitle(Lion.Localize("Save", "Save"), UIControlState.Normal);
			deleteButton.SetTitle(Lion.Localize("Delete", "Delete"), UIControlState.Normal);



			saveButton.TouchUpInside += (sender, e) => {
				// retrieve data from UIneed 
				currentTodo.Title = nameText.Text;
				currentTodo.Done = doneSwitch.On;

				currentTodo.Id = AppDelegate.Current.TodoDB.Save (currentTodo); // unnecessary to grab the ID, but hey let's get it anyway

				NavigationController.PopToRootViewController (true);
			};

			deleteButton.TouchUpInside += (sender, e) => {
				AppDelegate.Current.TodoDB.Delete (currentTodo);

				NavigationController.PopToRootViewController (true);
			};
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);

			// bind data to UI
			nameText.Text = currentTodo.Title;
			doneSwitch.On = currentTodo.Done;
		}
	}
}

