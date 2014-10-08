using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using MonoTouch.CoreMotion;
using System.Threading.Tasks;
using MonoTouch.CoreLocation;
using MonoTouch.AVFoundation;
using MonoTouch.MapKit;

namespace iOSBackgrounding
{
	partial class MainController : UIViewController
	{
		public MainController (IntPtr handle) : base (handle)
		{
		}

		// The first background API we use if core location. Must be class scope. Otherwise the authorization dialog will disappear automatically.
		CLLocationManager locMan;

		// The second API is Audio/Video playback. In this case: speech synthesis.
		AVSpeechSynthesizer speechSynthesizer;

		CLGeocoder geoCoder;

		string previousDirection = string.Empty;
		string previousStreet = string.Empty;
		string previousRestaurant = string.Empty;

		bool updateUi = true;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// We must set up an AVAudioSession and tell iOS we want to playback audio. Only then can speech synthesis be used in the background.
			var session = AVAudioSession.SharedInstance ();
			session.SetCategory (AVAudioSessionCategory.Playback);
			session.SetActive (true);
			this.speechSynthesizer = new AVSpeechSynthesizer ();

			UIApplication.Notifications.ObserveDidEnterBackground ((sender, args) =>
			{
				this.updateUi = false;
				this.Say ("Entering background mode. I will keep you updated!");
			});

			UIApplication.Notifications.ObserveWillEnterForeground ((sender, args) =>
			{
				this.updateUi = true;
				this.Say ("Entering foreground. Updating UI!");
			});

			// Create an instance of the location manager.
			this.locMan = new CLLocationManager {
				ActivityType = CLActivityType.Other,
				DesiredAccuracy = 1,
				DistanceFilter = 1
			};

			// Apple restricted location services usage in iOS8. We must explicitly prompt the user for permission.
			// See also: http://motzcod.es/post/97662738237/scanning-for-ibeacons-in-ios-8
			if (UIDevice.CurrentDevice.CheckSystemVersion (8, 0))
			{
				this.locMan.AuthorizationChanged += (object sender, CLAuthorizationChangedEventArgs e) =>
				{
					Console.WriteLine("MapKit authorization changed to: " + e.Status);
					if(e.Status == CLAuthorizationStatus.AuthorizedAlways || e.Status == CLAuthorizationStatus.AuthorizedWhenInUse)
					{
						this.InitLocationServices ();
					}
				};

				// This app will start locations services while in foreground and keeps using them when backgrounded.
				// Therefore we do not need RequestAlwaysAuthorization().
				this.locMan.RequestWhenInUseAuthorization ();
			}
			else
			{
				this.InitLocationServices ();
			}
		}

		/// <summary>
		/// Inits the location services.
		/// </summary>
		void InitLocationServices ()
		{
			// Setup the map.
			this.mapView.ShowsUserLocation = true;
			this.mapView.SetUserTrackingMode (MonoTouch.MapKit.MKUserTrackingMode.FollowWithHeading, true);

			// We need the GeoCoder to do reverse searches on locations.
			this.geoCoder = new CLGeocoder ();

			// Start getting updates from the location manager.
			this.locMan.StartUpdatingLocation ();

			// This will be called in case something goes wrong regarding location updates.
			this.locMan.Failed += (object sender, NSErrorEventArgs e) => Console.WriteLine ("LocationManager failed: {0}", e.Error);

			// Handle location updates.
			locMan.LocationsUpdated += HandleLocationsUpdated; 
		}

		/// <summary>
		/// Gets called by the location manager if the current location has changed.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">location arguments</param>
		async void HandleLocationsUpdated (object sender, CLLocationsUpdatedEventArgs e)
		{
			// Do not use the UserLocation property here. It will not be updated while running in the background.
			var location = e.Locations [e.Locations.Length - 1];

			// Get a readable direction for the current course.
			string direction = Helpers.GetDirectionForCourse (location.Course);

			// Try to find a human readable location description.
			string street = await Helpers.GetStreetForLocation (this.geoCoder, location);

			// Search for restaurants near our location.
			string restaurant = await Helpers.FindNearestRestaurantAsync (location);

			// Constantly output to the console so we see something is going on.
			Console.WriteLine (string.Format ("Coordinates: {0:F3} / {1:F3}", location.Coordinate.Latitude, location.Coordinate.Longitude));

			bool streetChanged = previousStreet != street;
			bool directionChanged = previousDirection != direction;
			bool restaurantChanged = previousRestaurant != restaurant && !string.IsNullOrWhiteSpace (restaurant);

			// If street, direction or restaurant changes, play an audio cue.
			if (streetChanged || directionChanged || restaurantChanged)
			{
				previousStreet = street;
				previousDirection = direction;
				previousRestaurant = restaurant;

				// Update UI.
				var currentLocation = string.Format ("Street: {0}, Direction: {1}", street, direction);
				if (this.updateUi)
				{
					lblLocation.Text = currentLocation;
				}

				// Speech synthesis can be used in the background.
				string speakLocation = streetChanged ? string.Format ("You are now on {0} going {1}.", street, direction) : string.Format ("You're heading {0}.", direction);
				if (restaurantChanged)
				{
					speakLocation += string.Format ("Check out {0} if you're hungry!", restaurant);
				}

				// Say the current location.
				this.Say (speakLocation);

				// Also output to console.
				Console.WriteLine (speakLocation);
			}
		}

		/// <summary>
		/// Uses speech synthesis to say something.
		/// </summary>
		/// <param name="text">Text.</param>
		void Say (string text)
		{
			// Speak the current location.
			var utterance = new AVSpeechUtterance (text) {
				Rate = AVSpeechUtterance.MaximumSpeechRate / 4,
				Voice = AVSpeechSynthesisVoice.FromLanguage ("en-US"),
				Volume = .5f,
				PitchMultiplier = 1.0f
			};

			speechSynthesizer.SpeakUtterance (utterance);
		}
	}
}
