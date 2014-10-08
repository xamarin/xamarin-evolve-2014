using System;
using Xamarin.Forms;

namespace TipCalculator
{
    public class OldMainPage : ContentPage
    {
		Entry totalAmount;
		Label tipTotal, total, tipPercent;
		Slider tipPercentSlider;

		public OldMainPage()
        {
			Title = "Tip Calculator";
			Device.OnPlatform(
				iOS: () => BackgroundColor = Color.FromHex("#f0f0f0"),
				Default: () => {});

			Grid rootLayout = new Grid {
				RowSpacing = 10,
				ColumnSpacing = 10,
				Padding = new Thickness(10, Device.OnPlatform(20, 5, 5), 10, 5),
				ColumnDefinitions = {
					new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
					new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) }
				},
				RowDefinitions = {
					new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
					new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
					new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
					new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
				},
			};

			var label = new Label {
				Text = "Total Amount",
				YAlign = TextAlignment.Center,
				Font = Font.SystemFontOfSize(NamedSize.Large, FontAttributes.Bold),
			};
			Grid.SetRow(label, 0);
			Grid.SetColumn(label, 0);
			rootLayout.Children.Add(label);

			totalAmount = new Entry {
				Placeholder = "Enter Amount in USD",
				Keyboard = Keyboard.Numeric,
			};
			Grid.SetRow(totalAmount, 0);
			Grid.SetColumn(totalAmount, 1);
			rootLayout.Children.Add(totalAmount);

			label = new Label {
				Text = "Tip",
				YAlign = TextAlignment.Center,
				Font = Font.SystemFontOfSize(NamedSize.Large, FontAttributes.Bold),
			};
			Grid.SetRow(label, 1);
			Grid.SetColumn(label, 0);
			rootLayout.Children.Add(label);

			tipTotal = new Label {
				Text = "$0.00",
				TextColor = Color.Gray,
				YAlign = TextAlignment.Center,
				Font = Font.SystemFontOfSize(NamedSize.Large),
			};
			Grid.SetRow(tipTotal, 1);
			Grid.SetColumn(tipTotal, 1);
			rootLayout.Children.Add(tipTotal);

			label = new Label {
				Text = "Total",
				YAlign = TextAlignment.Center,
				Font = Font.SystemFontOfSize(NamedSize.Large, FontAttributes.Bold),
			};
			Grid.SetRow(label, 2);
			Grid.SetColumn(label, 0);
			rootLayout.Children.Add(label);

			total = new Label {
				Text = "$0.00",
				TextColor = Color.Gray,
				YAlign = TextAlignment.Center,
				Font = Font.SystemFontOfSize(NamedSize.Large),
			};
			Grid.SetRow(total, 2);
			Grid.SetColumn(total, 1);
			rootLayout.Children.Add(total);

			Grid bottomGrid = new Grid {
				ColumnSpacing = 10,
				Padding = 10,
				VerticalOptions = LayoutOptions.End,
				ColumnDefinitions = {
					new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
					new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
				},
				RowDefinitions = {
					new RowDefinition { Height = new GridLength(1, GridUnitType.Auto)},
					new RowDefinition { Height = new GridLength(1, GridUnitType.Auto)},
					new RowDefinition { Height = new GridLength(1, GridUnitType.Auto)},
					new RowDefinition { Height = new GridLength(1, GridUnitType.Auto)},
					new RowDefinition { Height = new GridLength(1, GridUnitType.Auto)},
				}
			};

			var sep = new BoxView() {
				BackgroundColor = Color.Accent,
				HeightRequest = 2,
			};

			Grid.SetRow(sep, 0);
			Grid.SetColumn(sep, 0);
			Grid.SetColumnSpan(sep, 2);
			bottomGrid.Children.Add(sep);

			var normalTip = new Button() {
				Text = "15%",
				BorderColor = Color.Accent,
				BorderWidth = 2,
				BorderRadius = 5,
			};
			Grid.SetRow(normalTip, 1);
			Grid.SetColumn(normalTip, 0);
			bottomGrid.Children.Add(normalTip);

			var generousTip = new Button() {
				Text = "20%",
				BorderColor = Color.Accent,
				BorderWidth = 2,
				BorderRadius = 5,
			};
			Grid.SetRow(generousTip, 1);
			Grid.SetColumn(generousTip, 1);
			bottomGrid.Children.Add(generousTip);

			label = new Label {
				Text = "Tip Percentage",
				YAlign = TextAlignment.Center,
				Font = Font.SystemFontOfSize(NamedSize.Large, FontAttributes.Bold),
			};

			Grid.SetRow(label, 2);
			Grid.SetColumn(label, 0);
			Grid.SetColumnSpan(label, 1);
			bottomGrid.Children.Add(label);

			tipPercent = new Label {
				Text = "15%",
				HorizontalOptions = LayoutOptions.End,
				Font = Font.SystemFontOfSize(NamedSize.Large),
				TextColor = Color.Gray,
				YAlign = TextAlignment.End,
			};
			Grid.SetRow(tipPercent, 2);
			Grid.SetColumn(tipPercent, 1);
			bottomGrid.Children.Add(tipPercent);

			tipPercentSlider = new Slider {
				Minimum = 0,
				Maximum = 100,
				Value = 15,
			};

			Grid.SetRow(tipPercentSlider, 3);
			Grid.SetColumn(tipPercentSlider, 0);
			Grid.SetColumnSpan(tipPercentSlider, 2);
			bottomGrid.Children.Add(tipPercentSlider);

			Button roundDn = new Button {
				Text = "Round Down",
				BorderColor = Color.Accent,
				BorderWidth = 2,
				BorderRadius = 5,
			};
			Grid.SetRow(roundDn, 4);
			Grid.SetColumn(roundDn, 0);
			bottomGrid.Children.Add(roundDn);

			Button roundUp = new Button {
				Text = "Round Up",
				BorderColor = Color.Accent,
				BorderWidth = 2,
				BorderRadius = 5,
			};
			Grid.SetRow(roundUp, 4);
			Grid.SetColumn(roundUp, 1);
			bottomGrid.Children.Add(roundUp);

			Grid.SetRow(bottomGrid, 3);
			Grid.SetColumn(bottomGrid, 0);
			Grid.SetColumnSpan(bottomGrid, 2);
			rootLayout.Children.Add(bottomGrid);

			this.Content = rootLayout;

			totalAmount.TextChanged += (sender, e) => CalculateTip(false, false);

			tipPercentSlider.ValueChanged += (sender, e) => {
				double pct = Math.Round(e.NewValue);
				tipPercent.Text = pct + "%";
				CalculateTip(false,false);
			};

			normalTip.Clicked += (sender, e) => tipPercentSlider.Value = 15;
			generousTip.Clicked += (sender, e) => tipPercentSlider.Value = 20;
			roundDn.Clicked += (sender, e) => CalculateTip(false, true);
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
    }
}

