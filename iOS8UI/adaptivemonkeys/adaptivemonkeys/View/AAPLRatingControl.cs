using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;

namespace AdaptivePhotos
{
    public class AAPLRatingControl : UIControl
    {
        private const int AAPLRatingControlMinimumRating = 0;
        private const int AAPLRatingControlMaximumRating = 4;

        private int currentrating;
        private UIVisualEffectView backgroundView;

        private NSArray ImageViews { get; set; }

        public int Rating
        {
            get
            {
                return currentrating;
            }

            set
            {
                if (currentrating != value)
                {
                    currentrating = value;
                    UpdateImageViews();
                }
            } 
        }

        public override bool IsAccessibilityElement
        {
            get
            {
                return false;
            }
            set
            {
                base.IsAccessibilityElement = value;
            }
        }

        public AAPLRatingControl()
        {
            Rating = AAPLRatingControlMinimumRating;
            var blurredEffect = UIBlurEffect.FromStyle(UIBlurEffectStyle.Light);
            backgroundView = new UIVisualEffectView(blurredEffect);
            backgroundView.ContentView.BackgroundColor = UIColor.FromWhiteAlpha(0.7f, 0.2f);
            Add(backgroundView);

			var append = "";

	
            var imageViews = new NSMutableArray();
            for (int rating = AAPLRatingControlMinimumRating; rating <= AAPLRatingControlMaximumRating; rating++)
            {
                var imageView = new UIImageView
                {
                    UserInteractionEnabled = true,

					Image = UIImage.FromBundle("ratingInactive" + append),
					HighlightedImage = UIImage.FromBundle("ratingActive" + append).ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal),
                    AccessibilityLabel = string.Format("{0} bananas", rating + 1)
                };

				imageView.HighlightedImage = imageView.HighlightedImage.ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);

                Add(imageView);
                imageViews.Add(imageView);
            }

            ImageViews = imageViews;
            UpdateImageViews();
            SetupConstraints();
        }

        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            UpdateRatingWithTouches(touches, evt);
        }

        public override void TouchesMoved(NSSet touches, UIEvent evt)
        {
            UpdateRatingWithTouches(touches, evt);
        }

        private void UpdateImageViews()
        {
            for (int i = 0; i < ImageViews.Count; i++)
                ImageViews.GetItem <UIImageView>(i).Highlighted = (i + AAPLRatingControlMinimumRating <= Rating);
        }

        private void UpdateRatingWithTouches(NSSet touches, UIEvent evt)
        {
            var touch = (UITouch)touches.AnyObject;
            var position = touch.LocationInView(this);
            var touchedView = HitTest(position, evt);

            for (int i = 0; i < ImageViews.Count; i++)
            {
                if (ImageViews.GetItem<UIView>(i) == touchedView)
                {
                    Rating = AAPLRatingControlMinimumRating + i;
                    SendActionForControlEvents(UIControlEvent.ValueChanged);
                }
            }
        }

        private void SetupConstraints()
        {
            backgroundView.TranslatesAutoresizingMaskIntoConstraints = false;
            var views = NSDictionary.FromObjectAndKey(backgroundView, new NSString("backgroundView"));
            var constraints = NSLayoutConstraint.FromVisualFormat("|[backgroundView]|", NSLayoutFormatOptions.DirectionLeadingToTrailing, null, views);
            AddConstraints(constraints);
            constraints = NSLayoutConstraint.FromVisualFormat("V:|[backgroundView]|", NSLayoutFormatOptions.DirectionLeadingToTrailing, null, views);
            AddConstraints(constraints);

            UIImageView lastImageView = null;
            for (int i = 0; i < ImageViews.Count; i++)
            {
                var imageView = ImageViews.GetItem <UIImageView>(i);
                imageView.TranslatesAutoresizingMaskIntoConstraints = false;

                NSDictionary currentImageViews = null;

                if (lastImageView != null)
                {
                    currentImageViews = NSDictionary.FromObjectsAndKeys(new object[] { imageView, lastImageView }, 
                        new string[] { "imageView", "lastImageView" });
                }
                else
                {
                    currentImageViews = NSDictionary.FromObjectAndKey(imageView, new NSString("imageView"));
                }

                constraints = NSLayoutConstraint.FromVisualFormat("V:|-4-[imageView]-4-|", NSLayoutFormatOptions.DirectionLeadingToTrailing, null, currentImageViews);
                AddConstraints(constraints);
                AddConstraint(NSLayoutConstraint.Create(imageView, NSLayoutAttribute.Width, NSLayoutRelation.Equal, 
                        imageView, NSLayoutAttribute.Height, 1.0f, 0.0f));

                if (lastImageView != null)
                {
                    constraints = NSLayoutConstraint.FromVisualFormat("[lastImageView][imageView(==lastImageView)]", NSLayoutFormatOptions.DirectionLeadingToTrailing, null, currentImageViews);
                }
                else
                {
                    constraints = NSLayoutConstraint.FromVisualFormat("|-4-[imageView]", NSLayoutFormatOptions.DirectionLeadingToTrailing, null, currentImageViews);
                }

                AddConstraints(constraints);
                lastImageView = imageView;
            }
				
            var actualImageViews = NSDictionary.FromObjectAndKey(lastImageView, new NSString("lastImageView"));
            constraints = NSLayoutConstraint.FromVisualFormat("[lastImageView]-4-|", NSLayoutFormatOptions.DirectionLeadingToTrailing, null, actualImageViews);
            AddConstraints(constraints);
        }

		public override void TraitCollectionDidChange(UITraitCollection previousTraitCollection)
		{
			if (previousTraitCollection == null)
				previousTraitCollection = new UITraitCollection();

			base.TraitCollectionDidChange(previousTraitCollection);

			if (TraitCollection.VerticalSizeClass == UIUserInterfaceSizeClass.Compact) 
			{
				CGAffineTransform t = CGAffineTransform.MakeIdentity(); 
				t.Translate(this.Frame.Width/2, 0); 
				t.Scale (0.5f, 0.5f); 

				this.Transform = t;
			} 
			else 
			{
				CGAffineTransform t = CGAffineTransform.MakeIdentity(); 
				t.Translate(0, 0); 
				t.Scale (1f, 1f); 

				this.Transform = t;
			}
		}


    }
}

