// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using UIKit;


namespace MyTableView.iOS
{
	public partial class MyCellView : UITableViewCell
	{
		public MyCellView (IntPtr handle) : base (handle)
		{
		}
		public void UpdateUIWithTitle(CoffeeShop coffeeShop){
			lbTitle.Text = coffeeShop.Name;
			lbDescription.Text = coffeeShop.PhoneNumber;
		}
	}
}
