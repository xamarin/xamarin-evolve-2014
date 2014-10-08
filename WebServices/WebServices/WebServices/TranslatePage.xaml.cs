using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Xml.Linq;
using WebServices.Core;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

namespace WebServices
{	
	/// <summary>
	/// Demonstrates text translation.
	/// </summary>
	public partial class TranslatePage : ContentPage 
	{	
		public TranslatePage ()
		{
			this.Title = "Translate";
			InitializeComponent ();
			this.BindingContext = this;
			this.translator = TranslatorFactory.CreateTranslator ();
			pickerFrom.SelectedIndex = 1;
			pickerTo.SelectedIndex = 0;

			var connectivityService = DependencyService.Get<IConnectivityService> ();
			if (connectivityService != null)
			{
				var indicator = this.FindByName<ConnectivityView> ("connectivityIndicator");
				connectivityService.CreateConnectivityWatchDog (connected => indicator.HasConnectivity = connected);
			}
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
					this.TranslateAsync ().ContinueWith (t => {
						Debug.WriteLine ("Translating failed! " + t.Exception);
					}, TaskContinuationOptions.OnlyOnFaulted);
				}
			}
		}

		async Task TranslateAsync()
		{
			this.activityIndicator.IsRunning = true;
			var translation = await this.translator.TranslateAsync (this.txtSource.Text, App.GetLanguageFromIndex (pickerFrom.SelectedIndex), App.GetLanguageFromIndex (pickerTo.SelectedIndex));
			this.activityIndicator.IsRunning = false;
			this.lblTranslation.Text = translation;
		}
	}


}

