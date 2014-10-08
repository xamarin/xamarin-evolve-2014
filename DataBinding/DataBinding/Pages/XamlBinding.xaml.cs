using Xamarin.Forms;
using DataBinding.ViewModels;

namespace DataBinding
{	
	public partial class XamlBinding : ContentPage
	{	
		public XamlBinding (ComicBookViewModel comicBookVM)
		{
			BindingContext = comicBookVM;

			InitializeComponent ();
		}
	}
}

