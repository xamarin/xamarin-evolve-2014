using Xamarin.Forms;
using System.Linq;

namespace FormsNavPatterns
{
	//TODO : Step 03-1 - Derive from MasterDetailPage
	public class EvolveMasterDetailPage : MasterDetailPage
	{
		public EvolveMasterDetailPage ()
		{

			//TODO : Step 03-2 - Create Master and Detail Pages
			//Master = new SessionsMenuPage ();
			//Detail = new DetailPage ();

			//TODO : Step 03-7 - Add nav bar
			//Detail = new NavigationPage (new DetailPage ());

			//TODO : Step 03-5 - Listen for event
//			MessagingCenter.Subscribe<SessionSelected> (this, "SessionSelected", (selection) => {
//				//var detailPage = this.Detail as DetailPage;
//
//				//TODO : Step 03-9 - Update session from detail page
//				var detailPage = ((NavigationPage)this.Detail).CurrentPage as DetailPage;
//
//				detailPage.UpdateSession(selection.Session);
//
//				this.IsPresented = false;
//			});

			//TODO : Step 03-6 - Initialize page
			//MessagingCenter.Send (new SessionSelected (Repository.GetSessions().FirstOrDefault()), "SessionSelected");

		}
	}
}