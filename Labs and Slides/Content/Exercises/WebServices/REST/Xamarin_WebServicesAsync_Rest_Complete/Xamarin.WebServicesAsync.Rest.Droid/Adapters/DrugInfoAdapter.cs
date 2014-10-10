using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Views;
using Android.Widget;

namespace Xamarin.WebServicesAsync.Rest.Droid.Adapters
{
    public class DrugInfoAdapter : BaseAdapter<Core.Model.DrugInfo>
    {
        private readonly Activity activity;
        public List<Core.Model.DrugInfo> DrugInformation { get; private set; }
        public DrugInfoAdapter(Activity context, IEnumerable<Core.Model.DrugInfo> drugInformation)
        {
            DrugInformation = new List<Core.Model.DrugInfo>(drugInformation);
            activity = context;
        }

        public override int Count
        {
            get { return DrugInformation.Count; }
        }

        public override Core.Model.DrugInfo this[int position]
        {
            get { return DrugInformation[position]; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem2, null);

            var drugInfo = DrugInformation[position];

            var name = view.FindViewById<TextView>(Android.Resource.Id.Text1);
            name.Text = !String.IsNullOrEmpty(drugInfo.Synonym) ? drugInfo.Synonym : drugInfo.Name;

            var rxcui = view.FindViewById<TextView>(Android.Resource.Id.Text2);
            rxcui.Text = !String.IsNullOrEmpty(drugInfo.Synonym) ? drugInfo.Name : String.Empty;

            return view;
        }

        public void ReloadData(IEnumerable<Core.Model.DrugInfo> drugInformation)
        {
            DrugInformation.Clear();
            DrugInformation.AddRange(drugInformation);
            NotifyDataSetChanged();
        }
    }
}