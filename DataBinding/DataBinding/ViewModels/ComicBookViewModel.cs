
namespace DataBinding.ViewModels
{
	public class ComicBookViewModel : BaseViewModel
	{
		public ComicBookViewModel ()
		{
		}

		int _seriesNumber;

		public int SeriesNumber { 
			get { return _seriesNumber; }
			set {
				if (_seriesNumber != value) {
					_seriesNumber = value;
					OnPropertyChanged ();
					TraceHelper.Trace (_seriesNumber);
				}
			}
		}

		string _seriesName;

		public string SeriesName  { 
			get { return _seriesName; }
			set {
				if (_seriesName != value) {
					_seriesName = value;
					OnPropertyChanged ();
					TraceHelper.Trace (_seriesName);
				}
			} 
		}

		string _writer;

		public string Writer  { 
			get { return _writer; }
			set {
				if (_writer != value) {
					_writer = value;
					OnPropertyChanged ();
					TraceHelper.Trace (_writer);
				}
			}
		}

		string _penciller;

		public string Penciller  { 
			get { return _penciller; }
			set {
				if (_penciller != value) {
					_penciller = value;
					OnPropertyChanged ();
					TraceHelper.Trace(_penciller);
				}
			} 
		}

		string _inker;

		public string Inker  { 
			get { return _inker; }
			set {
				if (_inker != value) {
					_inker = value;
					OnPropertyChanged ();
					TraceHelper.Trace (_inker);
				}
			}
		}

		string _colorist;

		public string Colorist  { 
			get { return _colorist; }
			set {
				if (_colorist != value) {
					_colorist = value;
					OnPropertyChanged ();
					TraceHelper.Trace (_colorist);
				}
			} 
		}

		string _letterer;

		public string Letterer  { 
			get { return _letterer; }
			set {
				if (_letterer != value) {
					_letterer = value;
					OnPropertyChanged ();
					TraceHelper.Trace (_letterer);
				}
			}
		}

		string _editor;

		public string Editor  { 
			get { return _editor; }
			set {
				if (_editor != value) {
					_editor = value;
					OnPropertyChanged ();
					TraceHelper.Trace (_editor);
				}
			}
		}

		string _storyTitle;

		public string StoryTitle  { 
			get { return _storyTitle; }
			set {
				if (_storyTitle != value) {
					_storyTitle = value;
					OnPropertyChanged ();
					TraceHelper.Trace (_storyTitle);
				}
			}
		}

		string _character;

		public string Character { 
			get { return _character; }
			set {
				if (_character != value) {
					_character = value;
					OnPropertyChanged ();
					TraceHelper.Trace (_character);
				}
			} 
		}

		string _isbn;

		public string ISBN { 
			get { return _isbn; }
			set {
				if (_isbn != value) {
					_isbn = value;
					OnPropertyChanged ();
					TraceHelper.Trace (_isbn);
				}
			}
		}

		string _barcode;

		public string Barcode { 
			get { return _barcode; }
			set {
				if (_barcode != value) {
					_barcode = value;
					OnPropertyChanged ();
					TraceHelper.Trace (_barcode);
				}
			} 
		}

		string _imageSmall;

		public string ImageSmall { 
			get { return _imageSmall; }
			set {
				if (_imageSmall != value) {
					_imageSmall = value;
					OnPropertyChanged ();
				}
			}
		}

		string _url;

		public string Url { 
			get { return _url; }
			set {
				if (_url != value) {
					_url = value;
					OnPropertyChanged ();
				}
			}
		}
	}
}

