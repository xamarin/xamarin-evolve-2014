using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Touch.iOS.GestureRecognizer
{
    //TODO: Step 12 - Create a custom Checkmark Gesture Recognizer
    public class CheckmarkGestureRecognizer : UIGestureRecognizer
    {
        //// declarations
        //protected PointF midpoint = PointF.Empty;
        //protected bool strokeUp = false;
        //
        ///// <summary>
        /////   Called when the touches end or the recognizer state fails
        ///// </summary>
        //public override void Reset()
        //{
        //    base.Reset();
        //
        //    strokeUp = false;
        //    midpoint = PointF.Empty;
        //}
        //
        ///// <summary>
        /////   Is called when the fingers touch the screen.
        ///// </summary>
        //public override void TouchesBegan(NSSet touches, UIEvent evt)
        //{
        //    base.TouchesBegan(touches, evt);
        //
        //    // we want one and only one finger
        //    if (touches.Count != 1)
        //        State = UIGestureRecognizerState.Failed;
        //
        //    Console.WriteLine(base.State.ToString());
        //}
        //
        ///// <summary>
        /////   Called when the touches are cancelled due to a phone call, etc.
        ///// </summary>
        //public override void TouchesCancelled(NSSet touches, UIEvent evt)
        //{
        //    base.TouchesCancelled(touches, evt);
        //    // we fail the recognizer so that there isn't unexpected behavior 
        //    // if the application comes back into view
        //    State = UIGestureRecognizerState.Failed;
        //}
        //
        ///// <summary>
        /////   Called when the fingers lift off the screen
        ///// </summary>
        //public override void TouchesEnded(NSSet touches, UIEvent evt)
        //{
        //    base.TouchesEnded(touches, evt);
        //    //
        //    if (State == UIGestureRecognizerState.Possible && strokeUp)
        //    {
        //        State = UIGestureRecognizerState.Recognized;
        //    }

        //    Console.WriteLine(base.State.ToString());
        //}
        //
        ///// <summary>
        /////   Called when the fingers move
        ///// </summary>
        //public override void TouchesMoved(NSSet touches, UIEvent evt)
        //{
        //    base.TouchesMoved(touches, evt);
        //
        //    // if we haven't already failed
        //    if (State != UIGestureRecognizerState.Failed)
        //    {
        //        // get the current and previous touch point
        //        var newPoint = (touches.AnyObject as UITouch).LocationInView(View);
        //        var previousPoint = (touches.AnyObject as UITouch).PreviousLocationInView(View);
        //
        //        // if we're not already on the upstroke
        //        if (!strokeUp)
        //        {
        //            // if we're moving down, just continue to set the midpoint at 
        //            // whatever point we're at. when we start to stroke up, it'll stick
        //            // as the last point before we upticked
        //            if (newPoint.X >= previousPoint.X && newPoint.Y >= previousPoint.Y)
        //            {
        //                midpoint = newPoint;
        //            }
        //                // if we're stroking up (moving right x and up y [y axis is flipped])
        //            else if (newPoint.X >= previousPoint.X && newPoint.Y <= previousPoint.Y && midpoint != PointF.Empty)
        //            {
        //                strokeUp = true;
        //            }
        //                // otherwise, we fail the recognizer
        //            else
        //            {
        //                State = UIGestureRecognizerState.Failed;
        //            }
        //        }
        //    }
        //
        //    Console.WriteLine(State.ToString());
        //}
    }
}
