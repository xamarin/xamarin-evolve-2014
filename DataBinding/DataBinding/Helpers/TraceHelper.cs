using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace DataBinding
{
	public static class TraceHelper
	{
		public static void Trace(string value, [CallerMemberName] string propertyName = null){
			Debug.WriteLine (string.Format("{0} has been updated to {1}", propertyName, value));
		}

		public static void Trace(int value, [CallerMemberName] string propertyName = null){
			Debug.WriteLine (string.Format("{0} has been updated to {1}", propertyName, value));
		}
	}
}

