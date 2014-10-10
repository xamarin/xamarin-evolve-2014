using System;
using System.Collections.Generic;

namespace Xamarin.WebServicesAsync.Rest.Core.DTO
{
	public class DrugGroup
	{
		public string name { get; set; }
		public List<ConceptGroup> conceptGroup { get; set; }
	}
}

