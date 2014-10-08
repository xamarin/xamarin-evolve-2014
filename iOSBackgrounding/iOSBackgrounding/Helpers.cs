using System;
using MonoTouch.MapKit;
using System.Threading.Tasks;
using MonoTouch.CoreLocation;

namespace iOSBackgrounding
{
	public static class Helpers
	{
		/// <summary>
		/// Converts a given course into a direction
		/// </summary>
		/// <returns>The direction for course.</returns>
		/// <param name="course">Course.</param>
		public static string GetDirectionForCourse(double course)
		{
			string direction = string.Empty;
			if(course > 337.5f && course < 360f || course >= 0f && course <= 22.5f)
			{
				direction = "North";
			}
			else if(course > 157.5f && course <= 202.5f)
			{
				direction = "South";
			}
			else if(course > 247.5f && course <= 292.5f)
			{
				direction = "West";
			}
			else if(course > 67.5f && course <= 112.5f)
			{
				direction = "East";
			}
			else if(course > 292.5f && course < 337.5f)
			{
				direction = "North West";
			}
			else if(course > 22.5f && course < 67.5f)
			{
				direction = "North East";
			}
			else if(course > 202.5f && course < 247.5f)
			{
				direction = "South West";
			}
			else if(course > 67.5f && course < 247.5f)
			{
				direction = "South East";
			}
			return direction;
		}

		/// <summary>
		/// Finds the nearest restaurant.
		/// </summary>
		/// <returns>The nearest restaurant.</returns>
		/// <param name="location">Location.</param>
		public async static Task<string> FindNearestRestaurantAsync(CLLocation location)
		{
			// Search for restaurants near our location.
			string restaurant = string.Empty;
			try
			{
				var searchRequest = new MKLocalSearchRequest
				{
					NaturalLanguageQuery = "food",
					Region = new MKCoordinateRegion(new CLLocationCoordinate2D(location.Coordinate.Latitude, location.Coordinate.Longitude), new MKCoordinateSpan(0.3f, 0.3f))
				};


				var localSearch = new MKLocalSearch(searchRequest);
				var localSearchResponse = await localSearch.StartAsync();
				if(localSearchResponse.MapItems != null && localSearchResponse.MapItems.Length > 0)
				{
					var mapItem = localSearchResponse.MapItems[0];
					restaurant = mapItem.Name;
				}
			}
			catch(Exception ex)
			{
				//Console.WriteLine("Error searching restaurants: " + ex);
			}
			return restaurant;
		}

		/// <summary>
		/// Getes the street for a given location.
		/// </summary>
		/// <returns>The string for location.</returns>
		/// <param name="geoCoder">Geo coder.</param>
		/// <param name="location">Location.</param>
		public async static Task<string> GetStreetForLocation(CLGeocoder geoCoder, CLLocation location)
		{
			// Try to find a human readable location description.
			var street = string.Empty;
			try
			{
				var placemarks = await geoCoder.ReverseGeocodeLocationAsync(location);
				if(placemarks != null && placemarks.Length > 0)
				{
					street = placemarks[0].Thoroughfare;
				}
			}
			catch(Exception ex)
			{
				// This can go wrong, especially on the Simulator.
				//Console.WriteLine("Geocoder error: " + ex);
				street = "(unknown)";
			}

			return street;
		}
	}
}

