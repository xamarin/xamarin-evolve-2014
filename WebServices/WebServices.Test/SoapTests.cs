using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebServices.Core;
using System.Threading.Tasks;
using System.IO;

namespace WebServices.Test
{
	[TestClass]
	public class SoapTests
	{
		[TestMethod]
		public async Task TestTranslateString()
		{
			var translator = new SoapTranslator();
			var result = await translator.TranslateAsync("Hallo Welt!", "de", "en");
			Assert.AreEqual("Hello world!", result, "Translating string failed!");
		}

		[TestMethod]
		public async Task TestDetectLanguage()
		{
			var translator = new SoapTranslator();
			var result = await translator.DetectLanguageAsync("Bonjour monde!");
			Assert.AreEqual("fr", result, "Detecting language failed!");
		}

		[TestMethod]
		public async Task TestSpeak()
		{
			var translator = new SoapTranslator();
			using (var resultStream = await translator.SpeakAsync("Thirty years later, but still: hallo, I'm a Mac!", "en"))
			{
				Assert.IsNotNull(resultStream, "Speaking text failed!");

				using (var destStream = File.Open("test_soap.mp3", FileMode.Create, FileAccess.Write))
				{
					await resultStream.CopyToAsync(destStream);
				}

				var info = new FileInfo("test_soap.mp3");
				Assert.IsTrue(info.Length > 5000, "Size of MP3 seems to be too small!");
			}
		}
	}
}