using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;
using MvvmCross.Binding.BindingContext;
using Android.Views;
using Android.Content.PM;
using CocosSharp;

namespace KeepOnDroning.Droid.Views
{
	[Activity(Label = "View for GameViewModel",
		Theme = "@style/Theme.Main",
		ScreenOrientation = ScreenOrientation.Landscape)]
	public class GameView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
			SetContentView(Resource.Layout.GameView);

			var gameView = (CCGameView)FindViewById(Resource.Id.GameView);
			//gameView.ViewCreated += GameDelegate.LoadGame;
        }
    }
}