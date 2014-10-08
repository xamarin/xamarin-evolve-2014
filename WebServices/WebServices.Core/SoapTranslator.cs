using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using WebServices.WebServiceCore.SOAP;

namespace WebServices.Core
{
	/// <summary>
	/// Uses the Microsoft Translator API via SOAP.
	/// </summary>
	internal class SoapTranslator : ITranslator
	{
		/// <summary>
		/// Creates a new instance.
		/// </summary>
		public SoapTranslator()
		{
			this.admAuth = new AdmAuthentication(TranslatorFactory.CLIENT_ID, TranslatorFactory.CLIENT_SECRET);
		}

		readonly AdmAuthentication admAuth;

		/// <summary>
		/// Translates a string to the supplied language code.
		/// http://msdn.microsoft.com/en-us/library/ff512421.aspx
		/// </summary>
		/// <param name="text">the text to translate</param>
		/// <param name="fromLanguage">source language code, for example 'en'</param>
		/// <param name="toLanguage">destination language code, for example 'de'</param>
		/// <returns>the translated text</returns>
		public async Task<string> TranslateAsync(string text, string fromLanguage, string toLanguage)
		{
			if (string.IsNullOrWhiteSpace(text))
			{
				return string.Empty;
			}

			if (text.Length > 10000)
			{
				throw new ArgumentOutOfRangeException(text, "Size of text cannot exceed 10,000 characters, was " + text.Length);
			}

			// Set Authorization header before sending the request
			await this.admAuth.EnsureValidToken();
			var httpRequestProperty = new HttpRequestMessageProperty();
			httpRequestProperty.Method = "POST";
			httpRequestProperty.Headers["Authorization"] = this.admAuth.Token.HeaderValue;

			// Use SOAP client (http://api.microsofttranslator.com/V2/Soap.svc).
			var client = new LanguageServiceClient();

			// Convert the begin/end-async or event based async API to something awaitable by using a TaskCompletionSource.
			var tcs = new TaskCompletionSource<string>();

			// Creates a block within which an OperationContext object is in scope.
			using (new OperationContextScope(client.InnerChannel))
			{
				OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = httpRequestProperty;

				client.TranslateCompleted += (sender, args) =>
				{
					Debug.WriteLine("TranslateCompleted(). Setting TCS.");
					if (args.Error != null)
					{
						tcs.SetException(args.Error);
						return;
					}

					tcs.TrySetResult(args.Result);
				};

				// Keep appId parameter blank as we are sending access token in authorization header.
				client.TranslateAsync("", text, fromLanguage, toLanguage, "text/html", "general");
			}

			string translationResult = await tcs.Task;
			Debug.WriteLine("Translation for source {0} from {1} to {2} is '{3}'", text, fromLanguage, toLanguage, translationResult);
			return translationResult;
		}

		/// <summary>
		/// Detects the language of a given text.
		/// http://msdn.microsoft.com/en-us/library/ff512427.aspx
		/// </summary>
		/// <param name="text">the text to perform detection upon</param>
		/// <returns>a language code or an empty string if detection failed</returns>
		public async Task<string> DetectLanguageAsync(string text)
		{
			if (string.IsNullOrWhiteSpace(text))
			{
				return string.Empty;
			}

			if (text.Length > 10000)
			{
				throw new ArgumentOutOfRangeException(text, "Size of text cannot exceed 10,000 characters, was " + text.Length);
			}

			// Set Authorization header before sending the request
			await this.admAuth.EnsureValidToken();
			var httpRequestProperty = new HttpRequestMessageProperty {Method = "POST"};
			httpRequestProperty.Headers["Authorization"] = this.admAuth.Token.HeaderValue;

			// Use SOAP client (http://api.microsofttranslator.com/V2/Soap.svc).
			var client = new LanguageServiceClient();

			// Convert the begin/end-async API to something awaitable by using a TaskCompletionSource.
			var tcs = new TaskCompletionSource<string>();

			// Creates a block within which an OperationContext object is in scope.
			using (new OperationContextScope(client.InnerChannel))
			{
				OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = httpRequestProperty;
				client.DetectCompleted += (sender, args) =>
				{
					Debug.WriteLine("DetectCompleted(). Setting TCS.");
					if (args.Error != null)
					{
						tcs.SetException(args.Error);
						return;
					}

					tcs.TrySetResult(args.Result);
				};

				// Keep appId parameter blank as we are sending access token in authorization header.
				client.DetectAsync("", text);
			}

			string detectedLanguage = await tcs.Task;
			Debug.WriteLine("Language detection for '{0}' returnd: '{1}'", text, detectedLanguage);
			return detectedLanguage;
		}

		/// <summary>
		/// Returns a stream that contains the text in audio format.
		/// http://msdn.microsoft.com/en-us/library/ff512411.aspx
		/// </summary>
		/// <param name="text">the text to speak</param>
		/// <param name="language">the language code of the text</param>
		/// <returns>an audio stream</returns>
		public async Task<Stream> SpeakAsync(string text, string language)
		{
			if (string.IsNullOrWhiteSpace(text))
			{
				return null;
			}

			if (text.Length > 2000)
			{
				throw new ArgumentOutOfRangeException(text, "Size of text cannot exceed 2,000 characters, was " + text.Length);
			}

			// Set Authorization header before sending the request
			await this.admAuth.EnsureValidToken();
			var httpRequestProperty = new HttpRequestMessageProperty
			{
				Method = "POST"
			};
			httpRequestProperty.Headers["Authorization"] = this.admAuth.Token.HeaderValue;

			// Use SOAP client (http://api.microsofttranslator.com/V2/Soap.svc).
			var client = new LanguageServiceClient();

			// Convert the begin/end-async API to something awaitable by using a TaskCompletionSource.
			var tcs = new TaskCompletionSource<Stream>();

			string downloadUrl = string.Empty;

			// Creates a block within which an OperationContext object is in scope.
			using (new OperationContextScope(client.InnerChannel))
			{
				OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = httpRequestProperty;
				client.SpeakCompleted += async (sender, args) =>
				{
					Debug.WriteLine("SpeakCompleted(). Setting TCS.");
					if (args.Error != null)
					{
						tcs.SetException(args.Error);
						return;
					}

					// The web service returns a URL that contains the downloadable audio file.
					downloadUrl = args.Result;
					using (var httpClient = new HttpClient())
					{
						var downloadStream = await httpClient.GetStreamAsync(downloadUrl);
						tcs.TrySetResult(downloadStream);
					}
				};

				// Keep appId parameter blank as we are sending access token in authorization header.
				client.SpeakAsync("", text, language, "audio/mp3", "MaxQuality");
			}

			Stream stream = await tcs.Task;
			Debug.WriteLine("Downlaod URL for audio is: '{0}'", downloadUrl);
			return stream;
		}
	}
}
