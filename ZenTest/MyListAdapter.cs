﻿using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using System.Collections.Generic;


namespace ZenTest
{
	public class MyListAdapter: BaseAdapter<TableItem> {
		List<TableItem> items;
		Activity context;
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
			return view;
		}
		public void ChangeItemSource(List<TableItem> newItems)
		{
			items  = newItems;
		}
	}
}

