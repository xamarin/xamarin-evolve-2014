using System;
using MonoTouch.MapKit;
using MonoTouch.CoreLocation;

namespace MappingApp
{
    public class CustomAnnotation : MKAnnotation
    {
        private string _title;
        public override string Title { get { return _title; } }

        public override CLLocationCoordinate2D Coordinate { get; set; }

        public CustomAnnotation (string title, CLLocationCoordinate2D coord)
        {
            _title = title;
            this.Coordinate = coord;
        }
    }
}

