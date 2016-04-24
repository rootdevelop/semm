using System;
using System.Collections.Generic;
using CocosSharp;
using CrashDrone.Common.Entities;
using Microsoft.Xna.Framework;

namespace CrashDrone.Common
{
    public class HudLayer : CCLayerColor
    {

        CCSprite energySprite;
        int energy;
        CCLabel energyLabel;

        NavigateButton buttonUp;
        NavigateButton buttonDown;

        public HudLayer(Action up, Action down) : base(CCColor4B.Transparent)
        {
            energy = 100;
            energySprite = new CCSprite("/Assets/Content/Images/Hud/battery.png");
            energySprite.Scale = 0.5f;
            AddChild(energySprite);

            energyLabel = new CCLabel("100%", "Fonts/MarkerFelt", 22, CCLabelFormat.SpriteFont);
            AddChild(energyLabel);

            buttonUp = new NavigateButton("up", 100, up);
            AddChild(buttonUp);

            buttonDown = new NavigateButton("down", -100, down);
            AddChild(buttonDown);
        }

        protected override void AddedToScene()
        {
            base.AddedToScene();

            var bounds = VisibleBoundsWorldspace;
            energySprite.Position = new CCPoint(bounds.MaxX * 0.1f, bounds.MaxY * 0.95f);
            energyLabel.Position = new CCPoint(bounds.MaxX * 0.1f, bounds.MaxY * 0.89f);

            buttonUp.Position = new CCPoint(bounds.MaxX * 0.9f, bounds.MaxY * 0.12f);
            buttonDown.Position = new CCPoint(bounds.MaxX * 0.1f, bounds.MaxY * 0.12f);
        }

        public void AddEnergy(int addedAmount)
        {
            addedAmount = Math.Abs(addedAmount);
            energy = energy + addedAmount;
            energyLabel.Text = energy + "%";
        }

        public void RemoveEnergy(int removedAmount)
        {
            removedAmount = Math.Abs(removedAmount);
            energy = energy - removedAmount;
            energyLabel.Text = energy + "%";
        }
    }
}

