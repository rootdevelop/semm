﻿using System;

using UIKit;
using MvvmCross.iOS.Views;

namespace KeepOnDroning.iOS
{
    public partial class CustomLocationView : MvxViewController
    {
        public CustomLocationView()
            : base("CustomLocationView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}


