using System;
using System.Linq;
using MonoTouch.CoreAnimation;
using MonoTouch.UIKit;
using System.Drawing;
using WcfServiceHost.Model;
using Xamarin.EnterpriseWcf.Client;

namespace Xamarin.EnterpriseWcf.iOS
{
    public class MyViewController : UIViewController
    {
        const float padding = 2.0f;
        const float controlHeight = 34.0f;

        private MonkeyServiceClient monkeyServiceClient;

        UIButton getRandomMonkeyButton, searchButton;

        private UILabel randomMonkeyName;

        private UITextField familyName, subfamilyName, genus;

        private UITableView results;

        private TableViewSource.MonkeyInformationSource monkeyInformationSource;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            InitializeHelloWorldServiceClient();

            View.Frame = UIScreen.MainScreen.Bounds;
            View.BackgroundColor = UIColor.White;
            View.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;

            getRandomMonkeyButton = CreateFlatButton();
            getRandomMonkeyButton.Frame = new RectangleF(padding, 22.0f, this.View.Frame.Width - (padding * 2), controlHeight);
            
            getRandomMonkeyButton.SetTitle("Get Random Monkey", UIControlState.Normal);

            getRandomMonkeyButton.TouchUpInside += (object sender, EventArgs e) => monkeyServiceClient.GetRandomMonkeyNameAsync();
            
            randomMonkeyName = new UILabel
            {
                Frame = new RectangleF(padding, getRandomMonkeyButton.Frame.Bottom, this.View.Frame.Width - (padding*2), controlHeight), 
                TextAlignment = UITextAlignment.Center
            };

            AddBottomBorder(randomMonkeyName, 2.0f);


            var searchY = randomMonkeyName.Frame.Bottom + (padding * 5);

            familyName = new UITextField
            {
                Frame = new RectangleF(1, searchY, 83, controlHeight), 
                BackgroundColor = UIColor.White, 
                Placeholder = "Family"
            };

            AddBottomBorder(familyName, 2.0f);

            subfamilyName = new UITextField
            {
                Frame = new RectangleF(85, searchY, 83, controlHeight), 
                Placeholder = "Subfamily"
            };
            AddBottomBorder(subfamilyName, 2.0f);

            genus = new UITextField
            {
                Frame = new RectangleF(170, searchY, 78, controlHeight), 
                Placeholder = "Genus"
            };
            AddBottomBorder(genus, 2.0f);

            searchButton = CreateFlatButton();
            searchButton.Frame = new RectangleF(250, searchY, 68, controlHeight);
            searchButton.SetTitle("Search", UIControlState.Normal);

            searchButton.TouchUpInside += (object sender, EventArgs e) =>
            {
                DismissKeyboard();

                monkeyServiceClient.GetMonkeyMatchAsync(
                    new MonkeyQuery()
                    {
                        Family = familyName.Text,
                        Subfamily = subfamilyName.Text,
                        Genus = genus.Text
                    });
            };

            results = new UITableView
            {
                Frame = new RectangleF(0, searchButton.Frame.Bottom + padding, 
                                        this.View.Frame.Width, 
                                        this.View.Frame.Height - searchButton.Frame.Bottom - padding)
            };

            monkeyInformationSource = new TableViewSource.MonkeyInformationSource(Enumerable.Empty<MonkeyInformation>());
            results.Source = monkeyInformationSource;


            View.AddSubviews(getRandomMonkeyButton, randomMonkeyName, familyName, subfamilyName, genus, searchButton, results);
        }

        //TODO: Step 6 - iOS - Initialize our Service
        private void InitializeHelloWorldServiceClient()
        {
            monkeyServiceClient = MonkeyServiceClientHelper.CreateMonkeyServiceClient();
            monkeyServiceClient.GetMonkeyMatchCompleted += GetMonkeyMatchCompleted;
            monkeyServiceClient.GetRandomMonkeyNameCompleted += GetRandomMonkeyNameCompleted;
        }

        void GetRandomMonkeyNameCompleted(object sender, GetRandomMonkeyNameCompletedEventArgs e)
        {
            string msg;

            if (e.Error != null)
                msg = e.Error.Message;
            else if (e.Cancelled)
                msg = "Request was canceled";
            else
                msg = e.Result;

            BeginInvokeOnMainThread(() => randomMonkeyName.Text = msg);
        }

        void GetMonkeyMatchCompleted(object sender, GetMonkeyMatchCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                var alert = new UIAlertView {Title = "Error", Message = e.Error.Message};

                alert.Show();

                return;
            }

            if (e.Cancelled)
            {
                var alert = new UIAlertView { Title = "Error", Message = "Request was canceled" };

                alert.Show();
                return;
            }

            monkeyInformationSource.RefreshData(results, e.Result);
        }

        private void DismissKeyboard()
        {
            familyName.ResignFirstResponder();
            subfamilyName.ResignFirstResponder();
            genus.ResignFirstResponder();
        }

        private void AddBottomBorder(UIView view, float borderSize)
        {
            var bottomBorder = CALayer.Create();
            bottomBorder.BorderColor = UIColor.LightGray.CGColor;
            bottomBorder.BorderWidth = borderSize;

            bottomBorder.Frame = new RectangleF(-borderSize, -borderSize, view.Frame.Width + (borderSize * 2), view.Frame.Height + borderSize);

            view.Layer.AddSublayer(bottomBorder);
        }

        private UIButton CreateFlatButton()
        {
            var button = UIButton.FromType(UIButtonType.Custom);
            button.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            button.VerticalAlignment = UIControlContentVerticalAlignment.Center;
            button.SetTitleColor(UIColor.White, UIControlState.Normal);
            button.Layer.BackgroundColor = View.TintColor.CGColor;
            button.Layer.CornerRadius = 8.0f;

            return button;
        }
    }
}

