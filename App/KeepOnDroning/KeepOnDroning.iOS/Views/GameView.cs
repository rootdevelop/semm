using System;

using UIKit;
using MvvmCross.iOS.Views;
using CrashDrone.Common;
using MvvmCross.Binding.BindingContext;
using KeepOnDroning.Core.ViewModels;

namespace KeepOnDroning.iOS
{
	public partial class GameView : MvxViewController
	{
		public GameView () : base ("GameView", null)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			var set = this.CreateBindingSet<GameView, GameViewModel>();
			set.Bind(BackButton).To(ViewModel => ViewModel.GoBackCommand);
			set.Apply();

			if (GameUIView != null)
			{
				// Set loading event to be called once game view is fully initialised
				GameUIView.ViewCreated += GameDelegate.LoadGame;
			}
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);

			if (GameUIView != null)
				GameUIView.Paused = true;
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);

			if (GameUIView != null)
				GameUIView.Paused = false;
		}
	}
}