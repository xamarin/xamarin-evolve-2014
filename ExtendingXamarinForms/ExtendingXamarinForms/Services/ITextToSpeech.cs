using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExtendingXamarinForms
{
	public interface ITextToSpeech
	{
		void Speak(string text);
	}
}
