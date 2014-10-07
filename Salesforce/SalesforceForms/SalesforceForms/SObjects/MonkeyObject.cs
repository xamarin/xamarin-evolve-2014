using System;
using Salesforce;

namespace SalesforceForms
{
	public class MonkeyObject : SObject
	{
		public MonkeyObject ()
		{
			this.PreparingUpdateRequest += PrepareForUpdate;
		}

		public override string ResourceName { 
			get { return "xamevolve14__Monkey__c"; } 

		}

		public string Name
		{
			get { return GetOption ("Name"); }
			set { SetOption ("Name", value); }
		}

		public string Expertise
		{
			get { return GetOption ("xamevolve14__Expertise__c"); }
			set { SetOption ("xamevolve14__Expertise__c", value); }
		}

		public string Species
		{
			get { return GetOption ("xamevolve14__Species__c"); }
			set { SetOption ("xamevolve14__Species__c", value); }
		}

		public DateTime? LastModified
		{
			get { 
				var val = GetOption ("LastModifiedDate");
				return !String.IsNullOrWhiteSpace(val) ? DateTime.Parse(val) : default(DateTime?) ; 
			}
			set { 
				throw new InvalidOperationException ("LastModifiedDate is a read-only field."); 
			}
		}

		public void PrepareForUpdate(object sender, UpdateRequestEventArgs args)
		{
			args.UpdateData.Remove ("LastModifiedDate"); // Prevents attempt to update a read-only field.
		}
	}
}

