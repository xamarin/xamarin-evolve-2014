using System.Threading.Tasks;
using System.IO;

namespace WebServices.Core
{
	/// <summary>
	/// Mock translator implementation.
	/// </summary>
	internal class MockTranslator : ITranslator
	{
		internal MockTranslator ()
		{
		}

		public async Task<string> TranslateAsync (string text, string fromLanguage, string toLanguage)
		{
			await Task.Delay (2000);
			return "Translated " + fromLanguage + " -> " + toLanguage + ": " + text;
		}

		public async Task<string> DetectLanguageAsync (string text)
		{
			await Task.Delay (200);
			return "en";
		}

		public Task<Stream> SpeakAsync (string text, string language)
		{
			// Cannot mock this easily...would have to get audio data from somewhere.
			return Task.FromResult<Stream> (null);
		}
	}
}

