using System;
using MonoTouch.CoreLocation;

namespace Demo3LocationUpdater
{
    public sealed class LocationUpdatedEventArgs : EventArgs
	{
        public CLLocation Location
        {
            get; private set;
        }
		
		public LocationUpdatedEventArgs(CLLocation location)
		{
            this.Location = location;
		}
	}
}

