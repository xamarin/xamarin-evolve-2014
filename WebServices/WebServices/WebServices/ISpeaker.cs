using System;
using System.IO;

namespace WebServices
{
	/// <summary>
	/// Xamarin Forms is mute. We need to do this per platform.
	/// </summary>
	public interface ISpeaker
	{
		/// <summary>
		/// Speak the specified stream.
		/// </summary>
		/// <param name="stream">Stream.</param>
		void Speak(Stream stream);
	}
}

