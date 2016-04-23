using System;
using CocosSharp;

namespace SpaceGame.Common
{
	public class InitialGameLayer : CCLayerColor
	{
		CCLabel helloLabel;

		public InitialGameLayer () : base (CCColor4B.Blue)
		{
			Schedule (RunGameLogic);
		}

		void RunGameLogic(float frameTimeInSeconds)
		{
			// Game loop
		}

		protected override void AddedToScene ()
		{
			base.AddedToScene ();

			helloLabel = new CCLabel("Hello Space Apps!", "Arial", 30, CCLabelFormat.SystemFont);
			helloLabel.PositionX = ContentSize.Height/2;
			helloLabel.PositionY = ContentSize.Width/2;
			helloLabel.Color = CCColor3B.White;
			AddChild (helloLabel);

			// Use the bounds to layout the positioning of our drawable assets
			CCRect bounds = VisibleBoundsWorldspace;
		}
	}
}