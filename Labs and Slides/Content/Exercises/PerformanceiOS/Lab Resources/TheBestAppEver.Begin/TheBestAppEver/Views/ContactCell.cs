using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace TheBestAppEver
{
	public class ContactCell : UITableViewCell
	{
		public static NSString Key = new NSString("contacts");
		public ContactCell (IntPtr handle) : base (handle)
		{

		}

		public ContactCell () : base (UITableViewCellStyle.Default, Key)
		{

		}

		Person contact;
		public Person Contact {
			get {
				return contact;
			}
			set {
				contact = value;
				TextLabel.Text = contact.ToString ();
			}
		}

	}
}

