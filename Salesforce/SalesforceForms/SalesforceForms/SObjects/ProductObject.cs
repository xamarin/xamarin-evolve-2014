using System;
using Salesforce;

namespace SalesforceForms
{
	// https://www.salesforce.com/us/developer/docs/api/Content/sforce_api_objects_product2.htm
	public class ProductObject : SObject
	{
		public ProductObject ()
		{
			this.PreparingUpdateRequest += PrepareForUpdate;
		}

		public override string ResourceName { 
			get { return "Product2"; } 

		}

		public string Name
		{
			get { return GetOption ("Name"); }
			set { SetOption ("Name", value); }
		}

		public string ProductCode
		{
			get { return GetOption ("xamevolve14__Expertise__c"); }
			set { SetOption ("xamevolve14__Expertise__c", value); }
		}

		public string Description
		{
			get { return GetOption ("Description"); }
			set { SetOption ("Description", value); }
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

