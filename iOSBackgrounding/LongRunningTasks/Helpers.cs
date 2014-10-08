using System;
using System.Text;
using MonoTouch.Foundation;
using System.Threading;

namespace LongRunningTasks
{
	public static class Helpers
	{
		public static void CalcPi(Action<string> piCallback, CancellationToken token)
		{
			CalculatePI.Process (1000000, piCallback, token);
		}
	}
}

