using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace SalesforceForms
{
	public class PropertyGroup : IEnumerable<Property>
	{
		public string Title { get; private set; }
		public ObservableCollection<Property> Properties { get; private set; }

		public PropertyGroup (string title)
		{
			Title = title;
			Properties = new ObservableCollection<Property> ();
		}

		public void Add (string name, string value, PropertyType type)
		{
			if (!string.IsNullOrWhiteSpace (value)) {
				Properties.Add (new Property (name, value, type));
			}
		}

		IEnumerator<Property> IEnumerable<Property>.GetEnumerator ()
		{
			return Properties.GetEnumerator ();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator ()
		{
			return Properties.GetEnumerator ();
		}

		public override string ToString ()
		{
			return Title;
		}
	}

	public class Property
	{
		public string Name { get; private set; }
		public string Value { get; private set; }
		public PropertyType Type { get; private set; }

		public Property (string name, string value, PropertyType type)
		{
			Name = name;
			Value = value.Trim ();
			Type = type;
		}

		public override string ToString ()
		{
			return string.Format ("{0} = {1}", Name, Value);
		}
	}

	public enum PropertyType
	{
		Generic,
		Phone,
		Email,
		Url,
		Twitter,
		Address,
	}
}

