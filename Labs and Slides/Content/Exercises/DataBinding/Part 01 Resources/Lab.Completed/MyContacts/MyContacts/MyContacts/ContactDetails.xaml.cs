using System;
using Xamarin.Forms;

namespace MyContacts
{
    public partial class ContactDetails : ContentPage
    {
        readonly Person person;

		public ContactDetails(Person person)
        {
			BindingContext = person;

            this.person = person;
            InitializeComponent();

            // Setup person
            headshot.Source = ImageSource.FromResource("MyContacts.Images." + person.HeadshotUrl);
            genderPicker.SelectedIndex = (person.Gender == Gender.Male) ? 0 : 1;

            // Handle changes
            genderPicker.SelectedIndexChanged += (sender, e) => person.Gender = genderPicker.SelectedIndex == 0 ? Gender.Male : Gender.Female;
        }

		void OnShow(object sender, EventArgs e)
		{
			person.Dob = person.Dob.AddYears(1);

		    this.DisplayAlert("Selected Contact", person.ToString(), "OK");
		}
    }
}
