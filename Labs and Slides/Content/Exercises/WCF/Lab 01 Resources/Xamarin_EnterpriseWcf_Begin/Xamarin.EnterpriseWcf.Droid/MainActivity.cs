using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.ServiceModel;
using WcfServiceHost.Model;
using Android.Views.InputMethods;
using System.Linq;
using Xamarin.EnterpriseWcf.Client;

namespace Xamarin.EnterpriseWcf.Droid
{
    [Activity(Label = "Enterprise WCF", MainLauncher = true, Icon = "@drawable/ic_launcher", WindowSoftInputMode=SoftInput.StateHidden)]
    public class MainActivity : Activity
    {
        private MonkeyServiceClient monkeyServiceClient;

        private EditText familyText, subfamilyText, genusText;
        private TextView randomMonkeyLabel;
        private Button getRandomMonkeyButton;
        private ImageButton searchButton;

        private ListView searchResultsList;

        private Adapters.MonkeyInformationAdapter adapter;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            InitializeHelloWorldServiceClient();

            getRandomMonkeyButton = FindViewById<Button>(Resource.Id.getRandomMonkeyButton);
            getRandomMonkeyButton.Click += getRandomMonkeyButton_Click;

            randomMonkeyLabel = FindViewById<TextView>(Resource.Id.randomMonkeyLabel);

            familyText = FindViewById<EditText>(Resource.Id.familyText);
            subfamilyText = FindViewById<EditText>(Resource.Id.subfamilyText);
            genusText = FindViewById<EditText>(Resource.Id.genusText);

            searchButton = FindViewById<ImageButton>(Resource.Id.searchButton);
            searchButton.Click += searchButton_Click;

            searchResultsList = FindViewById<ListView>(Resource.Id.searchResultsList);

            adapter = new Adapters.MonkeyInformationAdapter(this, Enumerable.Empty<MonkeyInformation>());
            searchResultsList.Adapter = adapter;
        }

        void getRandomMonkeyButton_Click(object sender, EventArgs e)
        {
            monkeyServiceClient.GetRandomMonkeyNameAsync();
        }

        void searchButton_Click(object sender, EventArgs e)
        {
            var inputManager = (InputMethodManager)this.GetSystemService(Context.InputMethodService);
            inputManager.HideSoftInputFromWindow(this.CurrentFocus.WindowToken, HideSoftInputFlags.NotAlways);

            monkeyServiceClient.GetMonkeyMatchAsync(
                new WcfServiceHost.Model.MonkeyQuery()
                {
                    Family = familyText.Text,
                    Subfamily = subfamilyText.Text,
                    Genus = genusText.Text
                });
        }

        //TODO: Step 6 - Android - Initialize our Service
        private void InitializeHelloWorldServiceClient()
        {
        //    monkeyServiceClient = MonkeyServiceClientHelper.CreateMonkeyServiceClient();
        //    monkeyServiceClient.GetMonkeyMatchCompleted += GetMonkeyMatchCompleted;
        //    monkeyServiceClient.GetRandomMonkeyNameCompleted += GetRandomMonkeyNameCompleted;
        }

        void GetRandomMonkeyNameCompleted(object sender, GetRandomMonkeyNameCompletedEventArgs e)
        {
            var msg = string.Empty;

            if (e.Error != null)
                msg = e.Error.Message;
            else if (e.Cancelled)
                msg = "Request was canceled";
            else
                msg = e.Result;

            RunOnUiThread(() => randomMonkeyLabel.Text = msg);
        }

        void GetMonkeyMatchCompleted(object sender, GetMonkeyMatchCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                Toast.MakeText(this, e.Error.Message, ToastLength.Short).Show();
                return;
            }

            if (e.Cancelled)
            {
                Toast.MakeText(this, "Request was canceled", ToastLength.Short).Show();
                return;
            }

            adapter.RefreshData(e.Result);
        }
    }
}

