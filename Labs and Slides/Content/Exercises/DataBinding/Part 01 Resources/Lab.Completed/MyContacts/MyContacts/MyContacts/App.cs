using Xamarin.Forms;

namespace MyContacts
{
    public class App
    {
        public static Page GetMainPage()
        {
			return new NavigationPage(
				new ContactDetails(SimpsonFactory.GetPerson()));
        }
    }
}
