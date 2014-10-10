using System;
using MonoTouch.Dialog;

namespace TheBestAppEver
{
	public class RootViewController : DialogViewController
	{
		SongsViewController songs;
		public RootViewController () : base(null)
		{
			songs = new SongsViewController ();
			Root = new RootElement ("The best App ever!") {
				new Section ("") {
					new StringElement ("Contacts", () => ActivateController (new ContactsViewController ())),
					new StringElement ("Songs", () => ActivateController (songs)),
					new StringElement("Todo Items",()=> ActivateController(new TodoViewController())),
				}
			};
		}

		
	}
}

