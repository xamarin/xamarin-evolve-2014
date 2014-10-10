using NUnit.Framework;
using System;
using Phoneword.Core;

namespace Phoneword.UnitTests.Core
{
	[TestFixture]
	public class TestTranslation
	{
		[Test]
		public void TestXamarinPhoneNumber ()
		{
			var originalNumber = "1-855-XAMARIN";
			var expectedValue = "1-855-9262746";

			var translatedNumber = PhonewordTranslator.ToNumber (originalNumber);
			Assert.AreEqual (expectedValue, translatedNumber, "The expected phone numbers are not equivilant");
		}
	}
}

