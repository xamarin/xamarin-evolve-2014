using System;
using MonoTouch.UIKit;
using System.Drawing;

namespace TheBestAppEver
{
	public class TodoItemCell : UITableViewCell
	{
		public const string Key = "todoCell";
		UIImageView checkImage;

		public TodoItemCell () : base (UITableViewCellStyle.Default,Key)
		{
			// TODO: Step 3a load smaller image
			//checkImage = new UIImageView (new RectangleF(0,0,25,25)) {Image = UIImage.FromFile ("check.png").ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate)};
			//checkImage = new UIImageView (new RectangleF(0,0,25,25)) {Image = UIImage.FromFile ("small_check.png").ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate)};

			// TODO: Step 3b cache the image with FromBundle
			checkImage = new UIImageView (new RectangleF(0,0,25,25)) {Image = UIImage.FromBundle ("small_check.png").ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate)};
			AccessoryView = checkImage;
		}

		public override void PrepareForReuse ()
		{
			base.PrepareForReuse ();
			// TODO: Step 3c do not reload image each time.
			//AccessoryView = checkImage = new UIImageView (new RectangleF(0,0,25,25)) {Image = UIImage.FromFile ("check.png").ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate)};
		}

		TodoItem item;
		public TodoItem Item {
			get {
				return item;
			}
			set {
				item = value;
				AccessoryView.TintColor = item.Completed ? UIColor.Black : UIColor.LightGray;
				TextLabel.Text = item.Title;
			}
		}
	}
}

