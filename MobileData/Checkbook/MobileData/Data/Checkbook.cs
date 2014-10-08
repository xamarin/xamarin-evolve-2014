using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Specialized;
using System.Windows.Input;

namespace MobileData
{
	public class Checkbook : BaseViewModel
	{
		CheckRepository repo = new CheckRepository();
		readonly Random rng = new Random();
		public ObservableCollection<Check> Register { get; private set; }

		Check selectedCheck;
		public Check SelectedCheck {
			get {
				return selectedCheck;
			}
			set {
				var oldValue = selectedCheck;
				if (SetValue(ref selectedCheck, value)) {
					if (oldValue != null) {
						oldValue.PropertyChanged -= OnCurrentCheckChanged;
					}
					if (selectedCheck != null) {
						selectedCheck.PropertyChanged += OnCurrentCheckChanged;
					}
				}
			}
		}

		public ICommand AddNewCheck { get; private set; }

		public Checkbook()
		{
			Register = new ObservableCollection<Check>(repo.AllChecks);
			Register.CollectionChanged += HandleCollectionChanged;
			AddNewCheck = new DelegateCommand(_ => NewCheck());
		}

		void HandleCollectionChanged (object sender, NotifyCollectionChangedEventArgs e)
		{
			if (e.Action == NotifyCollectionChangedAction.Add) {
				foreach (var item in e.NewItems.Cast<Check>()) {
					Upsert(item);
				}
			}
			else if (e.Action == NotifyCollectionChangedAction.Remove) {
				foreach (var item in e.NewItems.Cast<Check>()) {
					if (item.Id != 0)
						repo.Delete(item);
				}
			}
		}

		void Upsert(Check check)
		{
			if (check.Id == 0)
				repo.Add(check);
			else
				repo.Update(check);
		}

		void OnCurrentCheckChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			Check check = (Check)sender;
			Upsert(check);
		}

		public Check NewCheck()
		{
			Check check = new Check() {
				CheckNumber = Register.Any() ? Register.Max(c => c.CheckNumber) + 1 : 101,
				Date = DateTime.Now.AddDays(rng.Next(-60, 60)),
				Amount = (rng.NextDouble() * 300) - rng.NextDouble() * 150,
				Cleared = (rng.Next(2) % 2 == 0),
				Payee = payees[rng.Next(payees.Length-1)],
			};

			Register.Add(check);

			return check;
		}

		static readonly string[] payees = {
			"Safeway Grocer",
			"Best Buy",
			"Walmart",
			"Costco",
			"Target",
			"Home Depot",
			"Apple",
			"Microsoft",
			"Sears",
			"Wendy's",
			"Steak and Shake",
			"In-n-Out Burger",
			"McDonalds",
			"7-11",
			"Exxon",
			"Honda",
			"Starbucks",
			"CVS",
			"Walgreens",
			"Subway",
			"Dominos Pizza",
			"AT&T",
		};
	}
}
