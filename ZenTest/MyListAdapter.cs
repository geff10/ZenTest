using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using System.Collections.Generic;


namespace ZenTest
{
	public class MyListAdapter: BaseAdapter<TableItem> {
		List<TableItem> items;
		Button buttonEdit;

		public List<TableItem> Items_
		{
			get { return items; }
			set { items = value; }
		}
		Activity context;
		bool visibleDeleteButton = false;
		public MyListAdapter(Activity context, List<TableItem> items)
			: base()
		{
			this.context = context;
			this.items = items;
		}
		public override long GetItemId(int position)
		{
			return position;
		}
		public override TableItem this[int position]
		{
			get { return items[position]; }
		}
		public override int Count
		{
			get { return items.Count; }
		}
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var item = items[position];
			View view = convertView;
			if (view == null)
				view = context.LayoutInflater.Inflate(Resource.Layout.CustomRow, null);
			view.FindViewById<TextView>(Resource.Id.Text1).Text = item.Heading;
			view.FindViewById<TextView>(Resource.Id.Text2).Text = item.SubHeading;
			buttonEdit = view.FindViewById<Button> (Resource.Id.deleteButton);
			buttonEdit.Visibility = visibleDeleteButton ? ViewStates.Visible : ViewStates.Invisible;

			buttonEdit.Click += delegate {
				List<TableItem> temp = new List<TableItem>();
				for (int i = 0; i < items.Count; i++) {
					if(i != position)
						temp.Add(this[i]);
				}
				items.Clear();
				int tempCount = items.Count - 1;
				for (int i = 0; i < tempCount; i++) {
					items.Add(temp[i]);
				}
				temp.Clear();
				Toast.MakeText(this.context, this.Count.ToString(), ToastLength.Short);

				//this.items.Remove(this.items[position]);
				this.NotifyDataSetChanged();

			};
			return view;
		}
		public void ChangeItemSource(List<TableItem> newItems)
		{
			items  = newItems;
		}

		public void SetVisibilityOfDeleteButton(bool visible)
		{
			visibleDeleteButton = visible;
		}
	}
}
	