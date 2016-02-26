using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using System.Collections.Generic;

namespace ZenTest
{
	[Activity (Label = "ZenTest", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		int count = 0;
		string[] items, items1, items2;
		List<TableItem> tableItems, tableItems1, tableItems2;
		MyListAdapter listAdapter;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.Main);

			Button buttonRefresh = FindViewById<Button> (Resource.Id.refreshButton);
			Button buttonEdit = FindViewById<Button> (Resource.Id.editButton);
			ListView listView = FindViewById<ListView>(Resource.Id.List);


			items1 = new string[] { "Föld", "Fák", "Víz", "Levegő", "Madarak", "Erdő" };
			items = items1;
			items2 = new string[] { "tarka", "kutya", "kaffog", "bőszen", "napon" };

			tableItems1 = new List<TableItem> ();
			for (int i = 0; i < items1.Length; i++) {
				tableItems1.Add( new TableItem ( items1[i], (i+1).ToString() ) );
			}
			tableItems2 = new List<TableItem> ();
			for (int i = 0; i < items2.Length; i++) {
				tableItems2.Add( new TableItem (items2[i], (i+10).ToString ()) );
			}
			tableItems = tableItems1;
			listAdapter = new MyListAdapter(this, tableItems);
			listView.Adapter = listAdapter;
			listAdapter.NotifyDataSetChanged(); 

			buttonRefresh.Click += delegate {
				tableItems = (count % 2 == 1) ?  tableItems1 : tableItems2;
				listAdapter.ChangeItemSource(tableItems);
				listAdapter.NotifyDataSetChanged(); 
				++count;
			};
		}//oncreate
	}
}


