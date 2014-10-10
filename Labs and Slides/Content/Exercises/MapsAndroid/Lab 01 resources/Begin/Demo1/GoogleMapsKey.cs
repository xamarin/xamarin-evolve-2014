using Android.App;

// Put your Google Maps V2 API Key here.
// See https://developers.google.com/maps/documentation/android/start#obtaining_an_api_key
// TODO: Step 1a - Enter your API key for using google services

#if RELEASE
[assembly: MetaDataAttribute("com.google.android.maps.v2.API_KEY", Value = "release_key_goes_here")]
#else
[assembly: MetaDataAttribute("com.google.android.maps.v2.API_KEY", Value = "debug_key_goes_here")]
#endif