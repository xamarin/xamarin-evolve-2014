using Xamarin.Forms;
using System;

namespace TipCalculator
{    
    public partial class MainPage : ContentPage
    {    
        public MainPage ()
        {
			Device.OnPlatform(
				iOS: () => BackgroundColor = Color.FromHex("#f0f0f0"),
				Default: () => {});

            InitializeComponent ();

			LayoutRoot.Padding = new Thickness(10, Device.OnPlatform(20, 5, 5), 10, 5);

			totalAmount.TextChanged += (sender, e) => CalculateTip(false, false);

			tipPercentSlider.ValueChanged += (sender, e) => {
				double pct = Math.Round(e.NewValue);
				tipPercent.Text = pct + "%";
				CalculateTip(false,false);
			};

			roundDown.Clicked += (sender, e) => CalculateTip(false, true);
			roundUp.Clicked += (sender, e) => CalculateTip(true, false);
        }

		private void CalculateTip (bool roundUp, bool roundDown)
		{
			double t;
			if (Double.TryParse(totalAmount.Text, out t) && t > 0)
			{
				double pct = Math.Round(tipPercentSlider.Value);
				double tip = Math.Round(t * (pct/100.0),2);

				double final = t + tip;
				if (roundUp) {
					final = Math.Ceiling(final);
					tip = final - t;
				} else if (roundDown) {
					final = Math.Floor(final);
					tip = final - t;
				}

				tipTotal.Text = tip.ToString("C");
				total.Text = final.ToString("C");
			}
		}

		private void OnNormalTip(object sender, EventArgs e)
		{
			tipPercentSlider.Value = 15;
		}

		private void OnGenerousTip(object sender, EventArgs e)
		{
			tipPercentSlider.Value = 20;
		}
    }
}

