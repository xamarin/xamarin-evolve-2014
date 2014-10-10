using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using WcfServiceHost.Model;

namespace Xamarin.EnterpriseWcf.Droid.Adapters
{
    internal class MonkeyInformationAdapter : BaseAdapter<MonkeyInformation>
    {
        Activity context;

        List<MonkeyInformation> monkeyInformation;

        public MonkeyInformationAdapter(Activity context, IEnumerable<MonkeyInformation> monkeyInformation)
            : base()
        {
            this.context = context;
            this.monkeyInformation = new List<MonkeyInformation>(monkeyInformation);
        } 

        public override MonkeyInformation this[int position]
        {
            get { return monkeyInformation[position]; }
        }

        public override int Count
        {
            get { return monkeyInformation.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? context.LayoutInflater.Inflate(Resource.Layout.MonkeyInformation, null);

            var familyName = view.FindViewById<TextView>(Resource.Id.familyNameText);
            var subfamily = view.FindViewById<TextView>(Resource.Id.subfamilyNameText);
            var commonName = view.FindViewById<TextView>(Resource.Id.commonNameText);
            var scientificNameText = view.FindViewById<TextView>(Resource.Id.scientificNameText);
            
            var monkeyOfInterest = monkeyInformation[position];

            familyName.Text = monkeyOfInterest.Family;
            subfamily.Text = monkeyOfInterest.Subfamily;
            commonName.Text = monkeyOfInterest.CommonName;
            scientificNameText.Text = monkeyOfInterest.ScientificName;

            return view;
        }

        public void RefreshData(IEnumerable<MonkeyInformation> updatedMonkeyInfo) {
            this.monkeyInformation.Clear();
            this.monkeyInformation.AddRange(updatedMonkeyInfo);

            context.RunOnUiThread(() => this.NotifyDataSetChanged());
        }
    }
}