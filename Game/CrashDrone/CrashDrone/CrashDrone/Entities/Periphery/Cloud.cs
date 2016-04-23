using CocosSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrashDrone.Common.Entities
{
    class Cloud :PeripheryEntity
    {
        private CCSprite _graphic;

        public Cloud()
        {
            this.Speed = CCRandom.GetRandomFloat(5f, 80f);
            InitGraphic();
        }


        private void InitGraphic()
        {
            _graphic = new CCSprite(String.Format("/Assets/Content/Images/Periphery/cloud{0}.png", CCRandom.GetRandomInt(1,2)));
            _graphic.IsAntialiased = false;
            _graphic.Opacity = 128;
            _graphic.Position = new CCPoint(_graphic.ContentSize.Width * 0.5f, _graphic.ContentSize.Height / 2);
            _graphic.AnchorPoint = new CCPoint(0.0f, 0.0f);
            AddChild(_graphic);
        }

        public override void Activity(float frameTimeInSeconds)
        {
            _graphic.PositionX -= Speed * frameTimeInSeconds;
        }
    }
}
