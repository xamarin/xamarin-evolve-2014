using System.Collections.Generic;
using System.Linq;
using Android.Widget;
using Android.Views;
using Android.Content;

namespace TheBestAppEver
{
	public class EnumerableAdapter<T> : BaseAdapter<T>
	{
		readonly List<T> data;
		readonly Context context;
		readonly int textViewResourceId;

		public EnumerableAdapter(Context context, int textViewResourceId, IEnumerable<T> data)
		{
			this.textViewResourceId = textViewResourceId;
			this.context = context;
			this.data = data.ToList();
		}

		public override int Count {
			get {
				return data.Count;
			}
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override T this[int index] {
			get { 
				return data[index];
			}
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var view = LayoutInflater.FromContext(context).Inflate(textViewResourceId, null);

			var item = this[position];
			var text = view.FindViewById<TextView>(Android.Resource.Id.Text1);
			text.Text = item.ToString();

			return view;
		}
	}
}

