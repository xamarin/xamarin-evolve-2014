using System;
using System.Diagnostics;
using Android.Util;

namespace TheBestAppEver
{
	public class Timer : IDisposable
	{
		readonly Stopwatch watch = Stopwatch.StartNew();
		readonly string text;

		public Timer(string text)
		{
			this.text = text;
		}

		public void Dispose()
		{
			watch.Stop();
			Log.Debug("Elapsed", text + " " + watch.Elapsed);
		}
	}
}

