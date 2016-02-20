// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace TodoList.iOS
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton AddBtn { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView TodoTableView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField TodoText { get; set; }

		[Action ("AddBtn_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void AddBtn_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (AddBtn != null) {
				AddBtn.Dispose ();
				AddBtn = null;
			}
			if (TodoTableView != null) {
				TodoTableView.Dispose ();
				TodoTableView = null;
			}
			if (TodoText != null) {
				TodoText.Dispose ();
				TodoText = null;
			}
		}
	}
}
