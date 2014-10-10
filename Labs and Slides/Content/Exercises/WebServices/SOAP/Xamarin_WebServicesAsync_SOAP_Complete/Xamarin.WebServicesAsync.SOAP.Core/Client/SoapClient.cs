using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.WebServicesAsync.Soap.Core.RxNav;

namespace Xamarin.WebServicesAsync.Soap.Core.Client
{
    public class SoapClient
    {

        
		public async Task<List<Model.DrugInfo>> GetDataAsync()
        {
			var drugInfo = new List<Model.DrugInfo> ();

			//TODO: Step 1 - create a SOAP client and Query for Information
			var foundMatches = await Task.Run(() =>
        	{
                using (var soapClient = new DBManagerService())
                    //Query for the drug named "aspirin"
					return soapClient.getDrugs("aspirin");
			}).ConfigureAwait(false);

			//TODO: Step 4 - map the response from the web service.
			drugInfo = await MapSoapDtoToDrugInfoAsync(foundMatches);

			return drugInfo;
        }

        
		private async Task<List<Core.Model.DrugInfo>> MapSoapDtoToDrugInfoAsync(RxConceptGroup[] rxConceptGroups)
        {
			if(rxConceptGroups == null)
				throw new ArgumentNullException("rxConceptGroups");

			var drugInfo = new List<Model.DrugInfo> ();

			//TODO: Step 2 - Convert the SOAP DTOs into model objects
            await Task.Run(() =>
            {
				drugInfo.AddRange(
                    from conceptGroup in rxConceptGroups
                    from concept in conceptGroup.rxConcept
					orderby concept.SY
                    select new Model.DrugInfo()
                    {
						//TODO: Step 3 - Map the DTO to the Model Object
                        Name = concept.STR,
                        Synonym = concept.SY
                    }
				);
			}).ConfigureAwait(false);

			return drugInfo;
        }
    }
}

