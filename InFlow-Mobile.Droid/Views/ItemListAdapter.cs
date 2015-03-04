using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using InFlow_Mobile.Core.ViewModels;

namespace InFlow_Mobile.Droid.Views
{
    public class ItemListAdapter : BaseAdapter<Item>
    {
        private List<Item> _items;
        private Activity _context;

        public ItemListAdapter(Activity context, List<Item> items)
        {
            _context = context;
            _items = items;
        }

        public override long GetItemId(int position)
        {
            return _items[position].ProdId;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            if (view == null)
                view = _context.LayoutInflater.Inflate(global::Android.Resource.Layout.SimpleListItem2, null);
            view.FindViewById<TextView>(global::Android.Resource.Id.Text1).Text = _items[position].Name;
            view.FindViewById<TextView>(global::Android.Resource.Id.Text2).Text = _items[position].Description;
            return view;
        }

        public override int Count
        {
            get { return _items.Count; }
        }

        public override Item this[int position]
        {
            get { return _items[position]; }
        }
    }
}