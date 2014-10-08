using Xamarin.Forms;

namespace DataBinding
{
	public static class UIHelper
	{
		public static Font CaptionFont = Device.OnPlatform(
			iOS:      Font.OfSize ("MarkerFelt-Thin", NamedSize.Medium),
			Android:  Font.OfSize ("Droid Sans Mono", NamedSize.Medium),
			WinPhone: Font.OfSize ("Comic Sans MS", NamedSize.Medium)
		);

		public static Color BarBackgroundColor = Color.FromHex("#15304E");
		public static Color BackgroundColor = Color.FromHex("#3B99D4");
		public static Color ForegroundColor = Color.White;
		public static Color ForegroundColor2 = Color.FromHex("#A956A0");
		public static Color TintColor = Color.FromHex("#7EC368");
		public static Color TintColor2 = Color.FromHex("#A956A0");
	}
}

