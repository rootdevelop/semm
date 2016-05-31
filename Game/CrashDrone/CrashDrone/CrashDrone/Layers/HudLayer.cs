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
        public int Score;
        CCLabel ScoreLabel;

        CCLabel RestartLabel;

        NavigateButton buttonUp;
        NavigateButton buttonDown;

        public HudLayer(Action up, Action down) : base(CCColor4B.Transparent)
        {
            Score = 0;
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

            ScoreLabel = new CCLabel("Score: 0", "Fonts/MarkerFelt", 22, CCLabelFormat.SpriteFont);
            ScoreLabel.Color = new CCColor3B(200, 48, 255);
            AddChild(ScoreLabel);

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
            ScoreLabel.Position = new CCPoint(bounds.MaxX * 0.25f, bounds.MaxY * 0.95f);
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

        public void AddScore(int increase)
        {
            Score += increase;
            ScoreLabel.Text = string.Format("Score: {0}", Score);
        }

        public void AddEnergy(int addedAmount)
        {
            addedAmount = Math.Abs(addedAmount);
            energy = energy + addedAmount;
            if (energy > 100)
            {
                energy = 100;
            }
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
            else if (this.energy > 0)
            {
                energyLabel.Color = CCColor3B.Red;
            }
            else
            {
                energyLabel.Color = CCColor3B.Black;
                energyLabel.Text = "GAME OVER";
            }
        }

        Drone drone;
        public void FlashRestart(Drone drone)
        {
            this.drone = drone;
            Schedule(CheckFlashStart);            
        }

        private void CheckFlashStart(float frameTimeInSeconds)
        {
            if (drone != null && drone.PositionY < 0)
            {

                RestartLabel = new CCLabel("Touch to restart", "Fonts/MarkerFelt", 22, CCLabelFormat.SpriteFont);
                RestartLabel.Color = new CCColor3B(200, 48, 255);
                RestartLabel.Position = new CCPoint(VisibleBoundsWorldspace.MaxX * 0.5f, VisibleBoundsWorldspace.MaxY * 0.5f);
                AddChild(RestartLabel);

                Schedule(FlashRestartInner);
                Unschedule(CheckFlashStart);
            }
        }

        private CCColor3B[] FlashColors = 
            {
            CCColor3B.Black, CCColor3B.White, CCColor3B.DarkGray, CCColor3B.Yellow, CCColor3B.Gray,
            CCColor3B.Magenta, CCColor3B.Blue, CCColor3B.Orange, CCColor3B.Green, CCColor3B.Red
        };

        private int _flashIndex = 1;
        private CCColor3B GetNextFlashColor()
        {
            if (_flashIndex < 9)
            {
                _flashIndex++;
            }
            else
            {
                _flashIndex = 0;
            }
            return FlashColors[_flashIndex];
        }

        private void FlashRestartInner(float frameTimeInSeconds)
        {
            RestartLabel.Color = GetNextFlashColor();
        }
    }
}

