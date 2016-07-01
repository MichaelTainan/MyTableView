// WARNING
//
// This file has been generated automatically by Xamarin Studio Community to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace MyTableView.iOS
{
	[Register ("MyCellView")]
	partial class MyCellView
	{
		[Outlet]
		UIKit.UILabel lbDescription { get; set; }

		[Outlet]
		UIKit.UILabel lbTitle { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lbTitle != null) {
				lbTitle.Dispose ();
				lbTitle = null;
			}

			if (lbDescription != null) {
				lbDescription.Dispose ();
				lbDescription = null;
			}
		}
	}
}
