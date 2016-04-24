using System;
using System.Collections.Generic;
using CocosSharp;
using CrashDrone.Common.Entities;
using Microsoft.Xna.Framework;

namespace CrashDrone.Common
{
    public class HudLayer : CCLayerColor
    {
        CCSprite Battery10;
        CCSprite Battery20;
        CCSprite Battery30;
        CCSprite Battery40;
        CCSprite Battery50;
        CCSprite Battery60;
        CCSprite Battery70;
        CCSprite Battery80;
        CCSprite Battery90;
        CCSprite Battery100;

        CCSprite energySprite;
        public int energy;
        CCLabel energyLabel;

        NavigateButton buttonUp;
        NavigateButton buttonDown;

        public HudLayer(Action up, Action down) : base(CCColor4B.Transparent)
        {
            energy = 100;

            Battery10 = new CCSprite("/Assets/Content/Images/Hud/red_block_battery.png");
            Battery10.Scale = 0.5f;
            AddChild(Battery10);

            Battery20 = new CCSprite("/Assets/Content/Images/Hud/red_block_battery.png");
            Battery20.Scale = 0.5f;
            AddChild(Battery20);

            Battery30 = new CCSprite("/Assets/Content/Images/Hud/orange_block_battery.png");
            Battery30.Scale = 0.5f;
            AddChild(Battery30);

            Battery40 = new CCSprite("/Assets/Content/Images/Hud/orange_block_battery.png");
            Battery40.Scale = 0.5f;
            AddChild(Battery40);

            Battery50 = new CCSprite("/Assets/Content/Images/Hud/orange_block_battery.png");
            Battery50.Scale = 0.5f;
            AddChild(Battery50);

            Battery60 = new CCSprite("/Assets/Content/Images/Hud/green_block_battery.png");
            Battery60.Scale = 0.5f;
            AddChild(Battery60);

            Battery70 = new CCSprite("/Assets/Content/Images/Hud/green_block_battery.png");
            Battery70.Scale = 0.5f;
            AddChild(Battery70);

            Battery80 = new CCSprite("/Assets/Content/Images/Hud/green_block_battery.png");
            Battery80.Scale = 0.5f;
            AddChild(Battery80);

            Battery90 = new CCSprite("/Assets/Content/Images/Hud/green_block_battery.png");
            Battery90.Scale = 0.5f;
            AddChild(Battery90);

            Battery100 = new CCSprite("/Assets/Content/Images/Hud/green_block_battery.png");
            Battery100.Scale = 0.5f;
            AddChild(Battery100);

            energySprite = new CCSprite("/Assets/Content/Images/Hud/battery.png");
            energySprite.Scale = 0.5f;
            AddChild(energySprite);

            energyLabel = new CCLabel("100%", "Fonts/MarkerFelt", 22, CCLabelFormat.SpriteFont);
            energyLabel.Color = CCColor3B.Green;
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
            Battery10.Position = new CCPoint(bounds.MaxX * 0.05f, bounds.MaxY * 0.95f);
            Battery20.Position = new CCPoint(bounds.MaxX * 0.06f, bounds.MaxY * 0.95f);
            Battery30.Position = new CCPoint(bounds.MaxX * 0.07f, bounds.MaxY * 0.95f);
            Battery40.Position = new CCPoint(bounds.MaxX * 0.08f, bounds.MaxY * 0.95f);
            Battery50.Position = new CCPoint(bounds.MaxX * 0.09f, bounds.MaxY * 0.95f);
            Battery60.Position = new CCPoint(bounds.MaxX * 0.10f, bounds.MaxY * 0.95f);
            Battery70.Position = new CCPoint(bounds.MaxX * 0.11f, bounds.MaxY * 0.95f);
            Battery80.Position = new CCPoint(bounds.MaxX * 0.12f, bounds.MaxY * 0.95f);
            Battery90.Position = new CCPoint(bounds.MaxX * 0.13f, bounds.MaxY * 0.95f);
            Battery100.Position = new CCPoint(bounds.MaxX * 0.14f, bounds.MaxY * 0.95f);

            buttonUp.Position = new CCPoint(bounds.MaxX * 0.9f, bounds.MaxY * 0.12f);
            buttonDown.Position = new CCPoint(bounds.MaxX * 0.1f, bounds.MaxY * 0.12f);
        }

        public void AddEnergy(int addedAmount)
        {
            addedAmount = Math.Abs(addedAmount);
            energy = energy + addedAmount;
            energyLabel.Text = energy + "%";
            SetBatteryVisibility();
        }

        public void RemoveEnergy(int removedAmount)
        {
            removedAmount = Math.Abs(removedAmount);
            energy = energy - removedAmount;
            energyLabel.Text = energy + "%";
            SetBatteryVisibility();
        }

        private void SetBatteryVisibility()
        {
            Battery10.Visible = this.energy >= 10;
            Battery20.Visible = this.energy >= 20;
            Battery30.Visible = this.energy >= 30;
            Battery40.Visible = this.energy >= 40;
            Battery50.Visible = this.energy >= 50;
            Battery60.Visible = this.energy >= 60;
            Battery70.Visible = this.energy >= 70;
            Battery80.Visible = this.energy >= 80;
            Battery90.Visible = this.energy >= 90;
            Battery100.Visible = this.energy >= 100;
            if (this.energy >= 60)
            {
                energyLabel.Color = CCColor3B.Green;
            }
            else if (this.energy >= 30)
            {
                energyLabel.Color = CCColor3B.Yellow;
            }
            else if (this.energy >= 10)
            {
                energyLabel.Color = CCColor3B.Red;
            }
            else
            {
                energyLabel.Color = CCColor3B.Black;
                energyLabel.Text = "GAME OVER";
            }
        }
    }
}

