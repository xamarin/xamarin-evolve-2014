using MonoTouch.UIKit;

namespace AdaptivePhotos
{
    public class AAPLEmptyViewController : CustomViewController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var view = new UIView
            {
                BackgroundColor = UIColor.White
            };

            var label = new UILabel
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                Text = "No Conversation Selected",
                TextColor = UIColor.FromWhiteAlpha(0.0f, 0.4f),
                Font = UIFont.PreferredHeadline
            };
            view.AddSubview(label);

            view.AddConstraint(NSLayoutConstraint.Create(label, NSLayoutAttribute.CenterX, NSLayoutRelation.Equal, 
                    view, NSLayoutAttribute.CenterX, 1.0f, 0.0f));
            view.AddConstraint(NSLayoutConstraint.Create(label, NSLayoutAttribute.CenterY, NSLayoutRelation.Equal, 
                    view, NSLayoutAttribute.CenterY, 1.0f, 0.0f));

            View = view;
        }
    }
}

