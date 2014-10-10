using NUnit.Framework;
using Phoneword.Core;
using System;

namespace Phoneword.UnitTests.Core
{
	[TestFixture]
	public class TestPhoneTranslateViewModel
	{
		MainViewModel _appViewModel;
		PhoneTranslateViewModel _translateViewModel;

		[SetUp]
		public void SetupViewModels()
		{
			_appViewModel = new MainViewModel (new Mocks.TestDialer ());
			_translateViewModel = new PhoneTranslateViewModel (_appViewModel);
		}

		[Test]
		public void TestNoTranslateOnEmptyText ()
		{
			_translateViewModel.PhoneNumberText = "";
			Assert.AreEqual (_translateViewModel.TranslateCommand.CanExecute (null), false);
		}

		[Test]
		public void TestPhoneNumberAllowsForTranslation ()
		{
			_translateViewModel.PhoneNumberText = "1-855-XAMARIN";
			Assert.AreEqual (_translateViewModel.TranslateCommand.CanExecute (null), true);
		}

		[Test]
		public void TestPhoneNumberTranslates ()
		{
			_appViewModel.DialledNumbers.Clear ();
			_translateViewModel.PhoneNumberText = "1-855-XAMARIN";

			Assert.AreEqual (_translateViewModel.TranslateCommand.CanExecute (null), true, 
				"The option to Transalte is not available");

			_translateViewModel.TranslateCommand.Execute (null);

			Assert.AreEqual (_translateViewModel.TranslatedNumber, "1-855-9262746", 
				"The phone number did not translate as expected");

			_translateViewModel.CallCommand.Execute (null);

			Assert.IsTrue (_appViewModel.DialledNumbers.Count == 1 && 
				_appViewModel.DialledNumbers[0] == "1-855-9262746");
		}
	}
}

