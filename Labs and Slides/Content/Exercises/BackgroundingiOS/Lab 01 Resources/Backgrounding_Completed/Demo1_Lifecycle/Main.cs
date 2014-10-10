using MonoTouch.UIKit;

namespace Demo1_AppLifecycle
{
	public class Application
	{
		// This is the main entry point of the application.
		static void Main (string[] args)
		{
			System.Console.WriteLine("Main entrypoint entered.");
			UIApplication.Main (args, null, "AppDelegate");
		}
	}
}
