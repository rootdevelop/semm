using System;
using System.Collections.Generic;
using CocosSharp;
using Microsoft.Xna.Framework;

namespace CrashDrone.Common
{
    public class HudLayer : CCLayerColor
    {

        CCSprite energySprite;
        int energy;
        CCLabel energyLabel;

        CCSprite buttonUp;
        CCSprite buttonDown;

        public HudLayer() : base(CCColor4B.Transparent)
        {
            energySprite = new CCSprite("/Assets/Content/Images/Hud/battery.png");
            energySprite.Scale = 0.5f;
            AddChild(energySprite);
            // create and initialize a Label
            energyLabel = new CCLabel("100%", "Fonts/MarkerFelt", 22, CCLabelFormat.SpriteFont);

            // add the label as a child to this Layer
            AddChild(energyLabel);
        }

        protected override void AddedToScene()
        {
            base.AddedToScene();

            // Use the bounds to layout the positioning of our drawable assets
            var bounds = VisibleBoundsWorldspace;
            energySprite.Position = new CCPoint(bounds.MaxX * 0.1f, bounds.MaxY * 0.95f);
            energyLabel.Position = new CCPoint(bounds.MaxX * 0.1f, bounds.MaxY * 0.85f);

            // Register for touch events
#warning add buttons for touch events
            //var touchListener = new CCEventListenerTouchAllAtOnce();
            //touchListener.OnTouchesEnded = OnTouchesEnded;
            //AddEventListener(touchListener, this);
        }

        public void AddEnergy(int addedAmount)
        {
            energy = energy + addedAmount;
            energyLabel.Text = energy + "%";
        }

        public void RemoveEnergy(int removedAmount)
        {
            energy = energy - removedAmount;
            energyLabel.Text = energy + "%";
        }

        void OnTouchesEnded(List<CCTouch> touches, CCEvent touchEvent)
        {
            if (touches.Count > 0)
            {
                // Perform touch handling here
            }
        }
	}
}

