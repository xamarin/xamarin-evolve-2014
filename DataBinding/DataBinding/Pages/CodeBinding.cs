using Xamarin.Forms;
using DataBinding.ViewModels;

namespace DataBinding
{
	public class CodeBinding : ContentPage
	{
		ComicBookViewModel _comicBook;

		/// <summary>
		/// Initializes a new instance of the <see cref="DataBinding.CodeBinding"/> class.
		/// </summary>
		/// <param name="comicBook">Comic book.</param>
		public CodeBinding (ComicBookViewModel comicBook)
		{
			_comicBook = comicBook;
			InitPage ();
			InitBindings();

			BackgroundColor = UIHelper.BackgroundColor;
			Title = _comicBook.SeriesName;
		}

		#region Setup Page
		/// <summary>
		/// Initializes the page controls.
		/// </summary>
		void InitPage ()
		{

			Font CaptionFont = Device.OnPlatform(
				iOS:      Font.OfSize ("MarkerFelt-Thin", NamedSize.Medium),
				Android:  Font.OfSize ("Droid Sans Mono", NamedSize.Medium),
				WinPhone: Font.OfSize ("Comic Sans MS", NamedSize.Medium)
			);

			BindingContext = _comicBook;

			CoverImage = new Image ();

			var stackLayout = new StackLayout {
				VerticalOptions = LayoutOptions.FillAndExpand,
				Padding = Device.OnPlatform(
					iOS:      new Thickness(5,20,5,5),
					Android:  new Thickness(5,0,5,5),
					WinPhone: new Thickness(5,0,5,5))
			};

			stackLayout.Children.Add (CoverImage);

			SeriesNoLbl = new Label {
				Text = Language.SeriesNumber, 
				Font = CaptionFont, 
				BackgroundColor = UIHelper.BackgroundColor,
				TextColor = UIHelper.ForegroundColor
			};

			SeriesNoEntry = new Entry ();

			stackLayout.Children.Add (SeriesNoLbl);
			stackLayout.Children.Add (SeriesNoEntry);

			SeriesNameLbl = new Label {
				Text = Language.SeriesName,
				Font = CaptionFont, 
				BackgroundColor = UIHelper.BackgroundColor,
				TextColor = UIHelper.ForegroundColor
			};

			SeriesNameEntry = new Entry ();

			stackLayout.Children.Add (SeriesNameLbl);
			stackLayout.Children.Add (SeriesNameEntry);

			WriterLbl = new Label {
				Text = Language.Writer,
				Font = CaptionFont, 
				BackgroundColor = UIHelper.BackgroundColor,
				TextColor = UIHelper.ForegroundColor
			};

			WriterEntry = new Entry ();

			stackLayout.Children.Add (WriterLbl);
			stackLayout.Children.Add (WriterEntry);

			PencillerLbl = new Label{
				Text=Language.Penciller,
				Font = CaptionFont, 
				BackgroundColor = UIHelper.BackgroundColor,
				TextColor = UIHelper.ForegroundColor
			};
			PencillerEntry = new Entry ();

			stackLayout.Children.Add (PencillerLbl);
			stackLayout.Children.Add (PencillerEntry);

			InkerLbl = new Label{
				Text=Language.Inker,
				Font = CaptionFont, 
				BackgroundColor = UIHelper.BackgroundColor,
				TextColor = UIHelper.ForegroundColor
			};

			InkerEntry = new Entry ();

			stackLayout.Children.Add (InkerLbl);
			stackLayout.Children.Add (InkerEntry);

			ColoristLbl = new Label {
				Text = Language.Colorist,
				Font = CaptionFont, 
				BackgroundColor = UIHelper.BackgroundColor,
				TextColor = UIHelper.ForegroundColor
			};

			ColoristEntry = new Entry ();

			stackLayout.Children.Add (ColoristLbl);
			stackLayout.Children.Add (ColoristEntry);

			LettererLbl = new Label {
				Text = Language.Letterer,
				Font = CaptionFont, 
				BackgroundColor = UIHelper.BackgroundColor,
				TextColor = UIHelper.ForegroundColor
			};

			LettererEntry = new Entry ();

			stackLayout.Children.Add (LettererLbl);
			stackLayout.Children.Add (LettererEntry);

			EditorLbl = new Label {
				Text = Language.Editor, 
				Font = CaptionFont, 
				BackgroundColor = UIHelper.BackgroundColor,
				TextColor = UIHelper.ForegroundColor
			};

			EditorEntry = new Entry ();

			stackLayout.Children.Add (EditorLbl);
			stackLayout.Children.Add (EditorEntry);

			StoryTitleLbl = new Label {
				Text = Language.StoryTitle, 
				Font = CaptionFont, 
				BackgroundColor = UIHelper.BackgroundColor,
				TextColor = UIHelper.ForegroundColor
			};

			StoryTitleEntry = new Entry ();

			stackLayout.Children.Add (StoryTitleLbl);
			stackLayout.Children.Add (StoryTitleEntry);

			CharacterLbl = new Label { 
				Text = Language.Character, 
				Font = CaptionFont, 
				BackgroundColor = UIHelper.BackgroundColor,
				TextColor = UIHelper.ForegroundColor
			};

			CharacterEntry = new Entry ();

			stackLayout.Children.Add (CharacterLbl);
			stackLayout.Children.Add (CharacterEntry);

			ISBNLbl = new Label {
				Text = Language.ISBN,
				Font = CaptionFont, 
				BackgroundColor = UIHelper.BackgroundColor,
				TextColor = UIHelper.ForegroundColor
			};

			ISBNEntry = new Entry ();

			stackLayout.Children.Add (ISBNLbl);
			stackLayout.Children.Add (ISBNEntry);

			BarcodeLbl = new Label { 
				Text = Language.Barcode,
				Font = CaptionFont, 
				BackgroundColor = UIHelper.BackgroundColor,
				TextColor = UIHelper.ForegroundColor
			};

			BarcodeEntry = new Entry ();

			stackLayout.Children.Add (BarcodeLbl);
			stackLayout.Children.Add (BarcodeEntry);

			var scrollView = new ScrollView () {
				Content = stackLayout
			};


			Content = scrollView;
		}
		#endregion

		#region Setup Bindings
		/// <summary>
		/// Initializes the bindings for the page controls.
		/// </summary>
		void InitBindings ()
		{
			CoverImage.SetBinding(Image.SourceProperty, "ImageSmall");

			SeriesNoEntry.SetBinding(Entry.TextProperty, 
				new Binding("SeriesNumber") {
					Mode = BindingMode.TwoWay
				});
			SeriesNameEntry.SetBinding(Entry.TextProperty, 
				new Binding("SeriesName") {
					Mode = BindingMode.TwoWay
				});
			WriterEntry.SetBinding(Entry.TextProperty, 
				new Binding("Writer") {
					Mode = BindingMode.TwoWay
				});
			PencillerEntry.SetBinding(Entry.TextProperty, 
				new Binding("Penciller") {
					Mode = BindingMode.TwoWay
				});
			InkerEntry.SetBinding(Entry.TextProperty, 
				new Binding("Inker") {
					Mode = BindingMode.TwoWay
				});
			ColoristEntry.SetBinding(Entry.TextProperty, 
				new Binding("Colorist") {
					Mode = BindingMode.TwoWay
				});
			LettererEntry.SetBinding(Entry.TextProperty, 
				new Binding("Letterer") {
					Mode = BindingMode.TwoWay
				});
			EditorEntry.SetBinding(Entry.TextProperty, 
				new Binding("Editor") {
					Mode = BindingMode.TwoWay
				});
			StoryTitleEntry.SetBinding(Entry.TextProperty, 
				new Binding("StoryTitle") {
					Mode = BindingMode.TwoWay
				});
			CharacterEntry.SetBinding(Entry.TextProperty, 
				new Binding("Character") {
					Mode = BindingMode.TwoWay
				});
			ISBNEntry.SetBinding(Entry.TextProperty, 
				new Binding("ISBN") {
					Mode = BindingMode.TwoWay
				});
			BarcodeEntry.SetBinding(Entry.TextProperty, 
				new Binding("Barcode") {
					Mode = BindingMode.TwoWay
				});
		}
		#endregion

		#region Control Definitions

		Image CoverImage { get; set; }
		Label SeriesNoLbl { get; set; }
		Entry SeriesNoEntry { get; set; }
		Label SeriesNameLbl { get; set; }
		Entry SeriesNameEntry { get; set; }
		Label WriterLbl { get; set; }
		Entry WriterEntry { get; set; }
		Label PencillerLbl { get; set; }
		Entry PencillerEntry { get; set; }
		Label InkerLbl { get; set; }
		Entry InkerEntry { get; set; }
		Entry ColoristEntry { get; set; }
		Label ColoristLbl { get; set; }
		Label LettererLbl { get; set; }
		Entry LettererEntry { get; set; }
		Label EditorLbl { get; set; }
		Entry EditorEntry { get; set; }
		Label StoryTitleLbl { get; set; }
		Entry StoryTitleEntry { get; set; }
		Label CharacterLbl { get; set; }
		Entry CharacterEntry { get; set; }
		Label ISBNLbl { get; set; }
		Entry ISBNEntry { get; set; }
		Label BarcodeLbl { get; set; }
		Entry BarcodeEntry { get; set; }

		#endregion
	}
}

