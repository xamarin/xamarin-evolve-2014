using Xamarin.Forms;
using DataBinding.Common;

namespace DataBinding.Pages
{
	public class MappingByHand: ContentPage 
	{
		readonly ComicBook _comicBook;

		/// <summary>
		/// Initializes a new instance of the <see cref="DataBinding.Pages.MappingByHand"/> class.
		/// </summary>
		/// <param name="comicBook">Comic book.</param>
		public MappingByHand (ComicBook comicBook)
		{
			_comicBook = comicBook;

			Title = _comicBook.SeriesName;

			InitPage ();
			HandleUpdates();
			BackgroundColor = UIHelper.BackgroundColor;
		}
			
		#region Setup Page
		/// <summary>
		/// Initializes the page.
		/// </summary>
		void InitPage ()
		{
			var stackLayout = new StackLayout {
				VerticalOptions = LayoutOptions.FillAndExpand,
				Padding = Device.OnPlatform(
					iOS:      new Thickness(5,20,5,5),
					Android:  new Thickness(5,0,5,5),
					WinPhone: new Thickness(5,0,5,5))
			};

			var coverImage = new Image ();
			coverImage.Source = _comicBook.ImageSmall;
			stackLayout.Children.Add (coverImage);

			SeriesNoLbl = new Label {
				Text = Language.SeriesNumber, 
				Font = UIHelper.CaptionFont, 
				BackgroundColor = UIHelper.BackgroundColor,
				TextColor = UIHelper.ForegroundColor
			};

			SeriesNoEntry = new Entry{
				Text = _comicBook.SeriesNumber.ToString()
			};
					
			stackLayout.Children.Add (SeriesNoLbl);
			stackLayout.Children.Add (SeriesNoEntry);

			SeriesNameLbl = new Label {
				Text = Language.SeriesName,
				Font = UIHelper.CaptionFont, 
				BackgroundColor = UIHelper.BackgroundColor,
				TextColor = UIHelper.ForegroundColor
			};

			SeriesNameEntry = new Entry{ 
				Text = _comicBook.SeriesName
			};

			stackLayout.Children.Add (SeriesNameLbl);
			stackLayout.Children.Add (SeriesNameEntry);

			WriterLbl = new Label {
				Text = Language.Writer,
				Font = UIHelper.CaptionFont, 
				BackgroundColor = UIHelper.BackgroundColor,
				TextColor = UIHelper.ForegroundColor
			};

			WriterEntry = new Entry {
				Text = _comicBook.Writer 
			};

			stackLayout.Children.Add (WriterLbl);
			stackLayout.Children.Add (WriterEntry);

			PencillerLbl = new Label{
				Text = Language.Penciller,
				Font = UIHelper.CaptionFont, 
				BackgroundColor = UIHelper.BackgroundColor,
				TextColor = UIHelper.ForegroundColor
			};

			PencillerEntry = new Entry{
				Text = _comicBook.Penciller
			};

			stackLayout.Children.Add (PencillerLbl);
			stackLayout.Children.Add (PencillerEntry);

			InkerLbl = new Label{
				Text=Language.Inker,
				Font = UIHelper.CaptionFont, 
				BackgroundColor = UIHelper.BackgroundColor,
				TextColor = UIHelper.ForegroundColor
			};

			InkerEntry = new Entry {
				Text = _comicBook.Inker
			};

			stackLayout.Children.Add (InkerLbl);
			stackLayout.Children.Add (InkerEntry);

			ColoristLbl = new Label {
				Text = Language.Colorist,
				Font = UIHelper.CaptionFont, 
				BackgroundColor = UIHelper.BackgroundColor,
				TextColor = UIHelper.ForegroundColor
			};

			ColoristEntry = new Entry { 
				Text = _comicBook.Colorist
			};

			stackLayout.Children.Add (ColoristLbl);
			stackLayout.Children.Add (ColoristEntry);

			LettererLbl = new Label {
				Text = Language.Letterer,
				Font = UIHelper.CaptionFont, 
				BackgroundColor = UIHelper.BackgroundColor,
				TextColor = UIHelper.ForegroundColor
			};

			LettererEntry = new Entry {
				Text = _comicBook.Letterer
			};

			stackLayout.Children.Add (LettererLbl);
			stackLayout.Children.Add (LettererEntry);

			EditorLbl = new Label {
				Text = Language.Editor, 
				Font = UIHelper.CaptionFont, 
				BackgroundColor = UIHelper.BackgroundColor,
				TextColor = UIHelper.ForegroundColor
			};

			EditorEntry = new Entry{
				Text = _comicBook.Editor
			};

			stackLayout.Children.Add (EditorLbl);
			stackLayout.Children.Add (EditorEntry);

			StoryTitleLbl = new Label {
				Text = Language.StoryTitle, 
				Font = UIHelper.CaptionFont, 
				BackgroundColor = UIHelper.BackgroundColor,
				TextColor = UIHelper.ForegroundColor
			};

			StoryTitleEntry = new Entry{
				Text = _comicBook.StoryTitle
			};

			stackLayout.Children.Add (StoryTitleLbl);
			stackLayout.Children.Add (StoryTitleEntry);

			CharacterLbl = new Label { 
				Text = Language.Character, 
				Font = UIHelper.CaptionFont, 
				BackgroundColor = UIHelper.BackgroundColor,
				TextColor = UIHelper.ForegroundColor
			};

			CharacterEntry = new Entry{
				Text = _comicBook.Character
			};

			stackLayout.Children.Add (CharacterLbl);
			stackLayout.Children.Add (CharacterEntry);

			ISBNLbl = new Label {
				Text = Language.ISBN,
				Font = UIHelper.CaptionFont, 
				BackgroundColor = UIHelper.BackgroundColor,
				TextColor = UIHelper.ForegroundColor
			};

			ISBNEntry = new Entry {
				Text = _comicBook.ISBN
			};

			stackLayout.Children.Add (ISBNLbl);
			stackLayout.Children.Add (ISBNEntry);

			BarcodeLbl = new Label { 
				Text = Language.Barcode,
				Font = UIHelper.CaptionFont, 
				BackgroundColor = UIHelper.BackgroundColor,
				TextColor = UIHelper.ForegroundColor
			};

			BarcodeEntry = new Entry {
				Text = _comicBook.Barcode
			};

			stackLayout.Children.Add (BarcodeLbl);
			stackLayout.Children.Add (BarcodeEntry);

			var scrollView = new ScrollView () {
				Content = stackLayout
			};

			Content = scrollView;
		}
		#endregion

		#region Handle Updates
		/// <summary>
		/// Handles updates to control values.
		/// </summary>
		void HandleUpdates ()
		{
			SeriesNoEntry.TextChanged += (sender, e) => {
				if (!e.NewTextValue.Equals(_comicBook.SeriesNumber)){
					int no;
					if (int.TryParse(e.NewTextValue, out no)){
						_comicBook.SeriesNumber = no;
						TraceHelper.Trace(_comicBook.SeriesNumber);
					}
				}
			};

			SeriesNameEntry.TextChanged += (sender, e) => {
				if (!e.NewTextValue.Equals(_comicBook.SeriesName)){
					_comicBook.SeriesName = e.NewTextValue;
					TraceHelper.Trace(_comicBook.SeriesName);
				}
			};

			WriterEntry.TextChanged += (sender, e) => {
				if (!e.NewTextValue.Equals(_comicBook.Writer)){
					_comicBook.Writer = e.NewTextValue;
					TraceHelper.Trace(_comicBook.Writer);
				}
			};

			PencillerEntry.TextChanged += (sender, e) => {
				if (!e.NewTextValue.Equals(_comicBook.Penciller)){
					_comicBook.Penciller = e.NewTextValue;
					TraceHelper.Trace(_comicBook.Penciller);
				}
			};

			InkerEntry.TextChanged += (sender, e) => {
				if (!e.NewTextValue.Equals(_comicBook.Inker)){
					_comicBook.Inker = e.NewTextValue;
					TraceHelper.Trace(_comicBook.Inker);
				}
			};

			ColoristEntry.TextChanged += (sender, e) => {
				if (!e.NewTextValue.Equals(_comicBook.Colorist)){
					_comicBook.Colorist = e.NewTextValue;
					TraceHelper.Trace(_comicBook.Colorist);
				}
			};

			LettererEntry.TextChanged += (sender, e) => {
				if (!e.NewTextValue.Equals(_comicBook.Letterer)){
					_comicBook.Letterer = e.NewTextValue;
					TraceHelper.Trace(_comicBook.Letterer);
				}
			};

			EditorEntry.TextChanged += (sender, e) => {
				if (!e.NewTextValue.Equals(_comicBook.Editor)){
					_comicBook.Editor = e.NewTextValue;
					TraceHelper.Trace(_comicBook.Editor);
				}
			};

			StoryTitleEntry.TextChanged += (sender, e) => {
				if (!e.NewTextValue.Equals(_comicBook.StoryTitle)){
					_comicBook.StoryTitle = e.NewTextValue;
					TraceHelper.Trace(_comicBook.StoryTitle);
				}
			};

			CharacterEntry.TextChanged += (sender, e) => {
				if (!e.NewTextValue.Equals(_comicBook.Character)){
					_comicBook.Character = e.NewTextValue;
					TraceHelper.Trace(_comicBook.Character);
				}
			};

			ISBNEntry.TextChanged += (sender, e) => {
				if (!e.NewTextValue.Equals(_comicBook.ISBN)){
					_comicBook.ISBN = e.NewTextValue;
					TraceHelper.Trace(_comicBook.ISBN);
				}
			};

			BarcodeEntry.TextChanged += (sender, e) => {
				if (!e.NewTextValue.Equals(_comicBook.Barcode)){
					_comicBook.Barcode = e.NewTextValue;
					TraceHelper.Trace(_comicBook.Barcode);
				}
			};
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

