using MonoTouch.UIKit;

namespace MasterDetailDemo
{
	public class NavBarDelegate : UIToolbarDelegate
	{
		public override UIBarPosition GetPositionForBar(IUIBarPositioning barPositioning)
		{
			return UIBarPosition.TopAttached;
		}
	}
}