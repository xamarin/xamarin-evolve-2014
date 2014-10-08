using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WebServices.Core
{
	/// <summary>
	/// REST implementation of the Microsoft Translator. Uses the Ajax service which returns JSON.
	/// There is also an HTTP service but that returns XML.
	/// </summary>
	internal class RestTranslator : ITranslator
	{
		/// <summary>
		/// Creates a new instance.
		/// </summary>
		public RestTranslator()
		{
			this.admAuth = new AdmAuthentication(TranslatorFactory.CLIENT_ID, TranslatorFactory.CLIENT_SECRET);
		}

		readonly AdmAuthentication admAuth;

		/// <summary>
		/// Translates a string to the supplied language code.
		/// http://msdn.microsoft.com/en-us/library/ff512406.aspx
		/// </summary>
		/// <param name="text">the text to translate</param>
		/// <param name="fromLanguage">source language code, for example 'en'</param>
		/// <param name="toLanguage">destination language code, for example 'de'</param>
		/// <returns>the translated text</returns>
		public async Task<string> TranslateAsync(string text, string fromLanguage, string toLanguage)
		{
			await this.admAuth.EnsureValidToken();

			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri("http://api.microsofttranslator.com/");
				client.DefaultRequestHeaders.Add("Authorization", this.admAuth.Token.HeaderValue);
				new HttpClientHandler().Ce

				var json = await client.GetStringAsync("v2/Ajax.svc/Translate?text=" + Uri.EscapeDataString(text) + "&from=" + Uri.EscapeDataString(fromLanguage) + "&to=" + Uri.EscapeDataString(toLanguage) + "&contentType=" + Uri.EscapeDataString("text/plain"));
				// Returned JSON is just a string.
				string translation = JsonConvert.DeserializeObject<string>(json);
				
				return translation;
			}
		}

		/// <summary>
		/// Detects the language of a given text.
		/// http://msdn.microsoft.com/en-us/library/ff512396.aspx
		/// </summary>
		/// <param name="text">the text to perform detection upon</param>
		/// <returns>a language code or an empty string if detection failed</returns>
		public async Task<string> DetectLanguageAsync(string text)
		{
			await this.admAuth.EnsureValidToken();

			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri("http://api.microsofttranslator.com/");
				client.DefaultRequestHeaders.Add("Authorization", this.admAuth.Token.HeaderValue);
				var json = await client.GetStringAsync("v2/Ajax.svc/Detect?text=" + Uri.EscapeDataString(text));

				// Returned JSON is just a string.
				string lang = JsonConvert.DeserializeObject<string>(json);
				
				return lang;
			}
		}

		/// <summary>
		/// Returns a stream that contains the text in audio format.
		/// http://msdn.microsoft.com/en-us/library/ff512405.aspx
		/// </summary>
		/// <param name="text">the text to speak</param>
		/// <param name="language">the language code of the text</param>
		/// <returns>an audio stream</returns>
		public async Task<Stream> SpeakAsync(string text, string language)
		{
			await this.admAuth.EnsureValidToken();

			var responseStream = new MemoryStream();

			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri("http://api.microsofttranslator.com/");
				client.DefaultRequestHeaders.Add("Authorization", this.admAuth.Token.HeaderValue);
				// Here we use the HTTP service instead of the AJAX service. This one directly returns an audio stream.
				// The AJAX version returns a URL but getting the stream directly is more convenient.
				var stream = await client.GetStreamAsync("v2/Http.svc/Speak?text=" + Uri.EscapeDataString(text) + "&language=" + language + "&format=" + Uri.EscapeDataString("audio/mp3") + "&options=MaxQuality");
				await stream.CopyToAsync(responseStream);
				responseStream.Seek(0, SeekOrigin.Begin);
			}

			return responseStream;
		}
	}
}
