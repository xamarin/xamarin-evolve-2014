using System;
using Android.App;

namespace Fragments
{
public interface IDisplayDetail
{
	bool CanDisplayDetail { get; }

	void DisplayDetail(Fragment fragmentToDisplay);

}
}

