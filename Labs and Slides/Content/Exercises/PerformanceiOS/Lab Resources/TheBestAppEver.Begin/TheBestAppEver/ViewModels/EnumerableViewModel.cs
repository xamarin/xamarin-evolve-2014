using System;
using System.Linq;
using System.Collections.Generic;

namespace TheBestAppEver
{
	public class EnumerableViewModel<T> : ViewModel<T> 
	{
		IEnumerable<T> items;
		public IEnumerable<T> Items {
			get {
				return items;
			}
			set {
				items = value;
				ProcItemsChanged ();
			}
		}

		public override int RowCount ()
		{
			return items.Count ();
		}
		public override int RowCount (int section)
		{
			return RowCount ();
		}

		public override int SectionCount ()
		{
			return 1;
		}

		public override T ItemForRow (int section, int row)
		{
			return items.ElementAt (row);
		}
		public override T ItemForRow (int row)
		{
			return items.ElementAt (row);
		}

		public override string HeaderTitle (int section)
		{
			return "";
		} 
	}
}

