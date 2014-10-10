using Xamarin.Forms;

namespace Calculator.WinPhone
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();

            Forms.Init();
            Content = Calculator.App.GetMainPage().ConvertPageToUIElement(this);
        }
    }
}
