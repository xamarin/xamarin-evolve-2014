namespace WebServices.Core
{
	/// <summary>
	/// Translator factory.
	/// </summary>
	public static class TranslatorFactory
	{
		/// <summary>
		/// Use your own client ID of the app here.
		/// </summary>
		public const string CLIENT_ID = "[YOUR CLIENT ID HERE]";

		// TODO 1: Provide correct Azure Data Market secret

		/// <summary>
		/// Use your own client secret here.
		/// </summary>
		public const string CLIENT_SECRET = "[YOUR CLIENT SECRET HERE]=";

		/// <summary>
		/// Create a translator.
		/// </summary>
		/// <returns>The translator.</returns>
		public static ITranslator CreateTranslator()
		{
			// TODO 2: Create the desired translator instance. 
			//return new MockTranslator ();
			//return new SoapTranslator ();
			return new RestTranslator ();
		}
	}
}

