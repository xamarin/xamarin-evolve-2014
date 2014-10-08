using System;
using System.Threading.Tasks;

namespace PhotoApp.PCL
{
	public interface ITakePhoto
	{
		bool IsAvailable { get; }

		Task<string> TakePhoto();
	}
}