using System;
using System.Collections.ObjectModel;

namespace SalesforceForms
{
	public class AccountViewModel
	{
		public AccountObject Account { get; private set; }

		public ObservableCollection<PropertyGroup> PropertyGroups { get; private set; }


		public AccountViewModel (AccountObject account)
		{
			if (account == null) {
				throw new ArgumentNullException ("account");
			}
			Account = account;

			PropertyGroups = new ObservableCollection<PropertyGroup> ();

			var general = new PropertyGroup ("General");
			general.Add ("Name", account.Name, PropertyType.Generic);
			general.Add ("Industry", account.Industry, PropertyType.Generic);
			general.Add ("Account", account.AccountNumber, PropertyType.Generic);
			general.Add ("Modified", account.LastModified==null?"":account.LastModified.ToString(), PropertyType.Generic);

			if (general.Properties.Count > 0) {
				PropertyGroups.Add (general);
			}

			var phone = new PropertyGroup ("Contact");

			phone.Add ("Phone", account.Phone, PropertyType.Phone);
			phone.Add ("Website", account.Website, PropertyType.Url);

			if (phone.Properties.Count > 0) {
				PropertyGroups.Add (phone);
			}
		}
	}
}

