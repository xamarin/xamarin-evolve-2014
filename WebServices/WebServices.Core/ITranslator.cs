using System.IO;
using System.Threading.Tasks;

namespace WebServices.Core
{
	/// <summary>
	/// Describes translation capabilities.
	/// </summary>
	public interface ITranslator
	{
		/// <summary>
		/// Translates a string to the supplied language code.
		/// </summary>
		/// <param name="text">the text to translate</param>
		/// <param name="fromLanguage">source language code, for example 'en'</param>
		/// <param name="toLanguage">destination language code, for example 'de'</param>
		/// <returns>the translated text</returns>
		Task<string> TranslateAsync(string text, string fromLanguage, string toLanguage);

		/// <summary>
		/// Detects the language of a given text.
		/// </summary>
		/// <param name="text">the text to perform detection upon</param>
		/// <returns>a language code or an empty string if detection failed</returns>
		Task<string> DetectLanguageAsync(string text);

		/// <summary>
		/// Returns a stream that contains the text in audio format.
		/// </summary>
		/// <param name="text">the text to speak</param>
		/// <param name="language">the language code of the text</param>
		/// <returns>an audio stream</returns>
		Task<Stream> SpeakAsync(string text, string language);
	}
}
