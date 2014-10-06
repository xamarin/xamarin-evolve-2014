using System;
using MonoTouch.Foundation;

namespace LionTodo
{
	public class Lion
	{
		public Lion ()
		{
		}

		public static string Localize(string key) {
			return NSBundle.MainBundle.LocalizedString (key, key);
		}

		public static string Localize(string key, string comment) {
			return NSBundle.MainBundle.LocalizedString (key, comment);
		}

		public static string Language {
			get { return NSLocale.PreferredLanguages[0]; }
		}

		public static string SupportedLanguages {
			get { 
				var languages = "";
				foreach (var l in NSLocale.ISOLanguageCodes)
					languages += " " + l;
				return languages; 
			}
		}

		public static string Locale {
			get { return NSLocale.CurrentLocale.LocaleIdentifier; }
		}

		public static string LocaleDisplayName {
			get { return NSLocale.CurrentLocale.GetIdentifierDisplayName(Locale); }
		}

		public static string SupportedLocales {
			get { 
				var locales = "";
				foreach (var l in NSLocale.AvailableLocaleIdentifiers)
					locales += " " + l;
				return locales;
			}
		}
	}
}

