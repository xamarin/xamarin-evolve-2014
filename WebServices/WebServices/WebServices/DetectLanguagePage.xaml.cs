using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Xml.Linq;
using WebServices.Core;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace WebServices
{	
	/// <summary>
	/// Demonstrates language detection.
	/// </summary>
	public partial class DetectLanguagePage : ContentPage 
	{	
		public DetectLanguagePage ()
		{
			this.Title = "Detect";
			InitializeComponent ();
			this.BindingContext = this;
			this.translator = TranslatorFactory.CreateTranslator ();
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			txtSource.Focus ();
		}

		ITranslator translator;

		const string SourceTextConstant = "SourceText";

		public string SourceText
		{
			get
			{
				return this.sourceText;
			}
			set
			{
				if (value.Equals (this.sourceText))
				{
					return;
				}
				this.sourceText = value;
				this.OnPropertyChanged ();
			}
		}
		string sourceText;

		protected override void OnPropertyChanged ([CallerMemberName] string propertyName = null)
		{
			base.OnPropertyChanged (propertyName);
			if (propertyName.Equals (SourceTextConstant))
			{
				if (txtSource.Text.EndsWith ("!", StringComparison.Ordinal) ||
				    txtSource.Text.EndsWith ("?", StringComparison.Ordinal) ||
				    txtSource.Text.EndsWith (".", StringComparison.Ordinal) ||
				    txtSource.Text.EndsWith (";", StringComparison.Ordinal))
				{
					this.DetectLanguageAsync ().ContinueWith (t => {
						Debug.WriteLine ("Detection failed! " + t.Exception);
					}, TaskContinuationOptions.OnlyOnFaulted);
				}
			}
		}

		async Task DetectLanguageAsync()
		{
			this.activityIndicator.IsRunning = true;
			var language = await this.translator.DetectLanguageAsync (this.txtSource.Text);
			this.activityIndicator.IsRunning = false;
			this.lblLanguage.Text = string.Format ("This looks to me like...{0}!", GetLanguageFromSymbol (language));
		}

		static string GetLanguageFromSymbol(string symbol)
		{
			switch (symbol)
			{
			case "en" : return "English";
			case "de" : return "German";
			case "fr" : return "French";
			default : return "I have no clue";
			}
		}
	}


}

