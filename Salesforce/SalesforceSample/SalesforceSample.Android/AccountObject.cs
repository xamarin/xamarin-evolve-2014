using Salesforce;

namespace SalesforceSample.Droid
{
	public class AccountObject : SObject
	{
		public override string ResourceName { get { return "Account"; } set { } }

		public string Name
		{
			get { return GetOption ("Name"); }
			set { SetOption ("Name", value); }
		}

		public string Phone
		{
			get { return GetOption ("Phone"); }
			set { SetOption ("Phone", value); }
		}

		public string Industry
		{
			get { return GetOption ("Industry"); }
			set { SetOption ("Industry", value); }
		}

		public string Website
		{
			get { return GetOption ("Website"); }
			set { SetOption ("Website", value); }
		}

		public string AccountNumber
		{
			get { return GetOption ("AccountNumber"); }
			set { SetOption ("AccountNumber", value); }
		}
	}
}