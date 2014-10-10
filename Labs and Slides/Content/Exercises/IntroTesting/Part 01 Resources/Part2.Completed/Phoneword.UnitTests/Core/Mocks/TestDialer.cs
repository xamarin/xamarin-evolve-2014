using NUnit.Framework;
using Phoneword.Core;
using System;

namespace Phoneword.UnitTests.Core.Mocks
{
	public class TestDialer : IDialer
	{
		public bool Dial (string number)
		{
			Console.WriteLine (string.Format ("Dialing {0}", number));
			return true;
		}
	}
}
