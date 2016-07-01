using Android.App;
using Android.Widget;
using Android.OS;
using System;
using System.Linq;
using System.Collections.Generic;
using Debug = System.Diagnostics.Debug;
using MyTableView;


namespace MyTableView.Droid
{
	[Activity (Label = "MyTableView", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{


		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			CoffeeShopWorker myWorkers = new CoffeeShopWorker ();
			myWorkers.ReadCoffeeShops ();

			var list = myWorkers.ReadCoffeeShops ();
			/*list.Add (@"1");
			list.Add (@"2");
			list.Add (@"3");*/
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);


			var listView = FindViewById <ListView> (Resource.Id.listviewcontainer_listview);
			listView.Adapter = new TitleListAdapter (this, list);
			listView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => {
				Debug.WriteLine(list[e.Position]);
			};
			/*listView.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) => {
				Debug.WriteLine(list[e.Position]);
			};*/
		}

		public class TitleListAdapter : BaseAdapter<string>{
			List<CoffeeShop> Titles { get; set; }
			Activity Context { get; set; }

			public TitleListAdapter(Activity context, List<CoffeeShop> titles ) :base(){
				Titles = new List<CoffeeShop>(titles);
				Context = context;
				
			}

			public override long GetItemId (int position)
			{
				return position;
			}

			public override string this[int index] {
				get {
					return Titles [index].Name;
				}
			}

			public override int Count {
				get {
					return Titles.Count;
				}
			}

			public override Android.Views.View GetView (int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
			{
				var item = Titles [position];
				var view = convertView;
				if (null == view) {
					view = Context.LayoutInflater.Inflate (Resource.Layout.listitemview, null);

				}
				var lbTitle = view.FindViewById<TextView> (Resource.Id.listitemview_lbTitle);
				var lbDescritpion = view.FindViewById<TextView> (Resource.Id.listitemview_lbDescription);
			lbTitle.Text = item.Name;
				lbDescritpion.Text = item.PhoneNumber;
				return view;
			}

		}
	}
}


