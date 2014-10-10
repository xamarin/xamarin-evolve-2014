using System.Net.Http;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json;
using System;

namespace Xamarin.WebServicesAsync.Rest.Core.Client
{
    public class RestClient
    {
        //TODO: Step 1 - Create a REST client
        private const string
            RestServiceBaseAddress = "http://rxnav.nlm.nih.gov/REST/",
            AcceptHeaderApplicationJson = "application/json";

        private HttpClient CreateRestClient()
        {
            var client = new HttpClient() { BaseAddress = new Uri(RestServiceBaseAddress) };

            client.DefaultRequestHeaders.Accept.Add(MediaTypeWithQualityHeaderValue.Parse(AcceptHeaderApplicationJson));

            return client;
        }


        public async Task<List<Model.DrugInfo>> GetDataAsync()
        {
            var drugInfo = new List<Model.DrugInfo>();

            //TODO: Step 2 - Call the web service and retrieve data

            var jsonResponse = string.Empty;

            using (var client = CreateRestClient())
            {
                var getDataResponse = await client.GetAsync("drugs?name=aspirin", HttpCompletionOption.ResponseContentRead).ConfigureAwait(false);

                //If we do not get a successful status code, then return an empty set
                if (!getDataResponse.IsSuccessStatusCode)
                    return drugInfo;

                //Retrieve the JSON response
                jsonResponse = await getDataResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            }

            //TODO: Step 5 - call to map JSON to model object
            if (string.IsNullOrEmpty(jsonResponse))
                return drugInfo;

            var parsedResponse = await Task.Run(() => JsonConvert.DeserializeObject<DTO.DrugResponse>(jsonResponse)).ConfigureAwait(false);

            drugInfo = await MapDtoToDrugInfo(parsedResponse).ConfigureAwait(false);

            return drugInfo;
        }


        private async Task<List<Model.DrugInfo>> MapDtoToDrugInfo(DTO.DrugResponse drugResponse)
        {
            if (drugResponse == null)
                throw new ArgumentNullException("drugResponse");

            var conceptProperties = new List<Model.DrugInfo>();

            //TODO: Step 3 - Convert DTO into model objects
            if (drugResponse.drugGroup != null && drugResponse.drugGroup.conceptGroup != null && drugResponse.drugGroup.conceptGroup.Any())
            {

                await Task.Run(() =>
                {
                    foreach (var conceptGroup in drugResponse.drugGroup.conceptGroup)
                    {

                        if (conceptGroup.conceptProperties != null && conceptGroup.conceptProperties.Any())
                        {

                            conceptProperties.AddRange(
                                conceptGroup.conceptProperties
                                    .OrderBy(cp => cp.synonym)
                                    .Select(cp =>
                                        new Model.DrugInfo()
                                        {
                                            //TODO: Step 4 - Map the DTO to Model
                                            Name = cp.name,
                                            Synonym = cp.synonym
                                        })
                            );

                        }

                    }
                }).ConfigureAwait(false);

            }

            return conceptProperties;
        }
    }
}

