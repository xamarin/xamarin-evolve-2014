using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace AdaptivePhotos
{
    public class AAPLOverlayView : UIView
    {
        private UILabel label;

        public string Text
        { 
            get
            {
                return label.Text;
            } 

            set
            {
                label.Text = value;
            }
        }

        public override SizeF IntrinsicContentSize
        {
            get
            {
                var size = label.IntrinsicContentSize;

                size.Width += TraitCollection.HorizontalSizeClass == UIUserInterfaceSizeClass.Compact ? 10.0f : 40.0f;
                size.Height += TraitCollection.VerticalSizeClass == UIUserInterfaceSizeClass.Compact ? 10.0f : 40.0f;

                return size;
            }
        }

        public AAPLOverlayView()
        {
            CreateView();
        }

        private void CreateView()
        {
            var effect = UIBlurEffect.FromStyle(UIBlurEffectStyle.Light);
            var backgroundView = new UIVisualEffectView(effect);
            backgroundView.ContentView.BackgroundColor = UIColor.FromWhiteAlpha(0.7f, 0.3f);
            backgroundView.TranslatesAutoresizingMaskIntoConstraints = false;
            Add(backgroundView);

            var views = NSDictionary.FromObjectAndKey(backgroundView, new NSString("backgroundView"));
            var constraints = NSLayoutConstraint.FromVisualFormat("|[backgroundView]|", 
                                  NSLayoutFormatOptions.DirectionLeadingToTrailing, null, views);
            AddConstraints(constraints);
            constraints = NSLayoutConstraint.FromVisualFormat("V:|[backgroundView]|", 
                NSLayoutFormatOptions.DirectionLeadingToTrailing, null, views);
            AddConstraints(constraints);

            label = new UILabel
            {
                TranslatesAutoresizingMaskIntoConstraints = false
            };
            Add(label);

            AddConstraint(NSLayoutConstraint.Create(label, NSLayoutAttribute.CenterX, NSLayoutRelation.Equal, 
                    backgroundView, NSLayoutAttribute.CenterX, 1.0f, 0.0f));
            AddConstraint(NSLayoutConstraint.Create(label, NSLayoutAttribute.CenterY, NSLayoutRelation.Equal, 
                    backgroundView, NSLayoutAttribute.CenterY, 1.0f, 0.0f));
        }

        public override void TraitCollectionDidChange(UITraitCollection previousTraitCollection)
        {
            if (previousTraitCollection == null)
                previousTraitCollection = new UITraitCollection();

            base.TraitCollectionDidChange(previousTraitCollection);

            if ((TraitCollection.VerticalSizeClass != previousTraitCollection.VerticalSizeClass) ||
                (TraitCollection.VerticalSizeClass != previousTraitCollection.HorizontalSizeClass))
            {
                InvalidateIntrinsicContentSize();
            }
        }
    }
}

