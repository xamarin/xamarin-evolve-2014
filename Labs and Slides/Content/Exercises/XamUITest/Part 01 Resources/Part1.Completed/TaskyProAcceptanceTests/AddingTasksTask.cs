using NUnit.Framework;
using System;
using System.Dynamic;
using Xamarin.UITest;

namespace TaskyProAcceptanceTests
{
	[TestFixture]
	public class AddingTasksTask
	{
		const string pathToApp = "../../../../../binaries/TaskyPro/iOS/TaskyiOS.app";

		IApp app;

		[SetUp]
		public void InitializeApp()
		{
			app = Xamarin.UITest.ConfigureApp.iOS.AppBundle (pathToApp).StartApp ();
		}

		void AddANewTask (string name, string description)
		{
			app.Tap (c => c.Button ().Marked ("Add"));
			app.EnterText (c => c.Class ("UITextField").Index (0), name);
			app.EnterText (c => c.Class ("UITextField").Index (1), description);
			app.Tap (c => c.Marked ("Save"));
		}

		[Test]
		public void TaskyPro_CreatingATask_ShouldBeSuccessful ()
		{
			AddANewTask ("Get Milk", "Pick up some milk");

			Assert.Greater (app.Query (c => c.Marked ("Get Milk")).Length, 0);
		}

		[Test]
		public void TaskyPro_DeletingATask_ShouldBeSuccessful ()
		{
			AddANewTask ("Test Delete", "This item should be deleted");
			app.Tap (c => c.Marked ("Test Delete"));
			app.Tap (c => c.Marked ("Delete"));

			Assert.AreEqual (app.Query (c => c.Marked ("Test Delete")).Length, 0);
		}
	}
}

