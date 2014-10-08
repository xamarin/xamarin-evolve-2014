using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;


// How to obtain an access token for Azure: http://msdn.microsoft.com/en-us/library/hh454950.aspx

namespace WebServices.Core
{
	/// <summary>
	/// Azure Data Market Access Token
	/// </summary>
	[DataContract]
	internal class AdmAccessToken
	{
		[DataMember(Name="access_token")]
		public string AccessToken { get; set; }
		[DataMember(Name="token_type")]
		public string TokenType { get; set; }
		[DataMember(Name="expires_in")]
		public string ExpiresInSeconds { get; set; }
		[DataMember(Name="scope")]
		public string Scope { get; set; }

		/// <summary>
		/// Returnd the header value that has to be passed for authorization.
		/// </summary>
		public string HeaderValue
		{
			get
			{
				return string.Format("Bearer {0}", this.AccessToken);
			}
		}
	}

	/// <summary>
	/// Azure Data Market Authentication
	/// </summary>
	public class AdmAuthentication
	{
		const string DATAMARKET_ACCESS_URI = "https://datamarket.accesscontrol.windows.net/v2/OAuth2-13";
		
		private readonly string requestDetails;
		DateTime tokenValidUntil = new DateTime();

		/// <summary>
		/// Creates a new instance.
		/// </summary>
		/// <param name="clientId">ID of the app</param>
		/// <param name="clientSecret">secret to authenticate the client</param>
		public AdmAuthentication(string clientId, string clientSecret)
		{
			// Create and remember the request string we have to send in order to obtain the authentication token.
			this.requestDetails = string.Format(
				"grant_type=client_credentials&client_id={0}&client_secret={1}&scope=http://api.microsofttranslator.com",
				Uri.EscapeDataString(clientId),
				Uri.EscapeDataString(clientSecret));
		}

		/// <summary>
		/// Retrieves and stores an authentication token. Tokens are valid for 10 minutes only.
		/// </summary>
		public async Task EnsureValidToken()
		{
			if (DateTime.Now <= this.tokenValidUntil)
			{
				return;
			}

			Debug.WriteLine("Token expired. Getting new one.");
			this.tokenValidUntil = this.tokenValidUntil.AddMinutes(9);

			using (var client = new HttpClient())
			{
				var request = new StringContent(this.requestDetails);
				request.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

				var response = await client.PostAsync(DATAMARKET_ACCESS_URI, request);

				// Spit out token in string represantation for debugging purposes.
				var tokenString = await response.Content.ReadAsStringAsync();
				Debug.WriteLine(tokenString);

				// Now get as stream and deserialize JSON to an object.
				using (var webResponse = await response.Content.ReadAsStreamAsync())
				{
					var serializer = new DataContractJsonSerializer(typeof(AdmAccessToken));
					this.Token = (AdmAccessToken)serializer.ReadObject(webResponse);
				}
			}
		}

		/// <summary>
		/// The current active authentication token. Call EnsureValidToken() to abtain a token.
		/// </summary>
		internal AdmAccessToken Token
		{
			get;
			private set;
		}
	}
}

