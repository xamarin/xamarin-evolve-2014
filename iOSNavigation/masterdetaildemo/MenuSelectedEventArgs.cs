using MonoTouch.Foundation;
using NavPatterns.Core;

namespace MasterDetailDemo
{
	public class MenuSelectedEventArgs
	{
		public MenuSelectedEventArgs (Session session)
		{
			Session = session;
		}
		public Session Session { get; set; }
	}
}