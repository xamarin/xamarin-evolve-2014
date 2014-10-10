using System;
using System.Collections.Generic;

namespace Xamarin.WebServicesAsync.Rest.Core.DTO
{
	public class ConceptGroup
	{
		public string tty { get; set; }
		public List<ConceptProperty> conceptProperties { get; set; }
	}
}

