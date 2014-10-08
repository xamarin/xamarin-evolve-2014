using MapKit;
using CoreLocation;

namespace Annotations
{
	//TODO : Demo 2 - Step 4 - Define custom annotation
	public class CustomAnnotation : MKAnnotation
	{
		readonly string _title;
		readonly string _subtitle;

		public override string Title { get { return _title; } }

		public override string Subtitle { get { return _subtitle; } }

		public override CLLocationCoordinate2D Coordinate { get; set; }

		public CustomAnnotation (CLLocationCoordinate2D coord, string title, string subtitle)
		{
			_title = title;
			_subtitle = subtitle;
			Coordinate = coord;
		}
	}
}