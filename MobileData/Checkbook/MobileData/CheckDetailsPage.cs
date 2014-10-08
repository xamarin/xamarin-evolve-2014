using Xamarin.Forms;
using System.Globalization;

namespace MobileData
{
    public class CheckDetailsPage : ContentPage
    {
		public CheckDetailsPage(Check check)
        {
			EntryCell payee, amount;
			SwitchCell cleared;

			Title = "Details";

			this.Content = new TableView {
				Intent = TableIntent.Form,
				Root = new TableRoot() {
					new TableSection("Check #" + check.Id) {
						new TextCell {
							Text = "Date",
							Detail = check.Date.ToString("D"),
						},
						(payee = new EntryCell {
							Label = "Payee",
							Placeholder = "Enter Payee",
							Text = check.Payee,
							Keyboard = Keyboard.Default,
						}),
						(amount = new EntryCell {
							Label = "Amount",
							Placeholder = "Enter Dollar Amount",
							Text = check.Amount.ToString("N2"),
							Keyboard = Keyboard.Numeric,
						}),
						(cleared = new SwitchCell {
							Text = "Cleared?",
							On = check.Cleared,
						}),
					},
				}
			};

			// Push updates back to models.
			payee.Completed += (sender, e) => check.Payee = payee.Text;
			amount.Completed += (sender, e) => check.Amount = double.Parse(amount.Text, NumberStyles.Currency);
			cleared.OnChanged += (sender, e) => check.Cleared = cleared.On;
        }
    }
}

