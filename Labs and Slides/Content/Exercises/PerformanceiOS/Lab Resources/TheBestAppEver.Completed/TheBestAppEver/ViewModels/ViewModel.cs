using System;

namespace TheBestAppEver
{
	public abstract class ViewModel <T>
	{
		public event EventHandler ItemsChanged;
		protected void ProcItemsChanged()
		{
			if(ItemsChanged != null)
				ItemsChanged(this,EventArgs.Empty);
		}

		public ViewModel ()
		{
		}

		public abstract int RowCount ();
		public abstract int RowCount (int section);
		public abstract int SectionCount ();
		public abstract T ItemForRow (int row);
		public abstract T ItemForRow (int section, int row);
		public abstract string HeaderTitle (int section);
	}

	public class EmptyViewModel<T> : ViewModel <T>
	{
		#region implemented abstract members of ViewModel

		public override int RowCount ()
		{
			return 0;
		}

		public override int RowCount (int section)
		{
			return 0;
		}

		public override int SectionCount ()
		{
			return 0;
		}

		public override T ItemForRow (int row)
		{
			return default(T);
		}

		public override T ItemForRow (int section, int row)
		{
			return default(T);
		}

		public override string HeaderTitle (int section)
		{
			return "";
		}

		#endregion


	}
}

