using System;
using System.Linq;
using System.Collections.Generic;

using Foundation;
using UIKit;
using Debug = System.Diagnostics.Debug;
using MyTableView;

namespace MyTableView.iOS
{
	public partial class ViewController : UIViewController
	{

		public ViewController (IntPtr handle) : base (handle)
		{		
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			CoffeeShopWorker myWorkers = new CoffeeShopWorker ();
			myWorkers.ReadCoffeeShops ();
			// Perform any additional setup after loading the view, typically from a nib.
			var list = myWorkers.ReadCoffeeShops ();
			//var list = new List<string>();
			/*list.Add (@"1");
			list.Add (@"2");
			list.Add (@"3");*/
		


			var source = new TableSource (list);
			myTabView.Source = source;
			//myTabView.Source = new TableSource (list);

			source.TitleSelected += delegate(object sender, TitleSelectedEventArgs e) {
				Debug.WriteLine(e.SelectedTitle);
			};
				
			myTabView.ReloadData ();

		}

		public override void DidReceiveMemoryWarning ()
		{		
			base.DidReceiveMemoryWarning ();		
			
		// Release any cached data, images, etc that aren't in use.		
		}

		public class TableSource : UITableViewSource {

			const string MyCellViewIdentifier = @"MyCellView";

			public List<CoffeeShop> Source{ get; set; }

			public TableSource(List<CoffeeShop> list){
				Source = new List<CoffeeShop>();
				Source.AddRange (list);
			}


			public override nint RowsInSection (UITableView tableview, nint section)
			{
				return Source.Count;
			}
				
			public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
			{
				var cell = tableView.DequeueReusableCell (MyCellViewIdentifier ) as MyCellView;
				var title = Source [indexPath.Row];
			

				cell.UpdateUIWithTitle (title);

				return cell;

			}

			public event EventHandler<TitleSelectedEventArgs > TitleSelected;

			public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
			{
				var title = Source [indexPath.Row];
				Debug.WriteLine (title.Name);

				tableView.DeselectRow (indexPath, true);

				//Raise Event 呼叫,喚起

				EventHandler<TitleSelectedEventArgs > handle = TitleSelected;

				if (null != handle) {
					var args = new TitleSelectedEventArgs { SelectedTitle = title.Name };
					handle (this, args);
				}
			}


		}

		public class TitleSelectedEventArgs :EventArgs {
			public string SelectedTitle { get; set;}
		}

	}
}
