using CocosSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrashDrone.Common.Entities
{
    public class Forest : PeripheryEntity
    {
        private CCSprite _graphic;
        private CCSprite _graphic2;

        public Forest() 
        {
            this.Speed = 50f;
            InitGraphic();
        }

        private void InitGraphic()
        {
            _graphic = new CCSprite("/Assets/Content/Images/Periphery/forest.png");
            _graphic.IsAntialiased = false;
            _graphic.Position = new CCPoint(_graphic.ContentSize.Width* 0.5f, _graphic.ContentSize.Height / 2);
            _graphic.AnchorPoint = new CCPoint(0.0f, 0.0f);
            AddChild(_graphic);

            _graphic2 = new CCSprite("/Assets/Content/Images/Periphery/forest.png");
            _graphic2.IsAntialiased = false;
            _graphic2.Position = new CCPoint(_graphic2.ContentSize.Width + _graphic2.ContentSize.Width * 0.5f, _graphic2.ContentSize.Height /2);
            _graphic.AnchorPoint = new CCPoint(0.5f, 0.5f);
            AddChild(_graphic2);
        }

        public override void Activity(float frameTimeInSeconds)
        {
           // _graphic.Position = _graphic.Position.Offset(-, 0);
            _graphic.PositionX -= Speed * frameTimeInSeconds;

            //_graphic2.Position = _graphic.Position.Offset(-Speed * frameTimeInSeconds, 0);
            _graphic2.PositionX -= Speed * frameTimeInSeconds;

            if (_graphic.PositionX <= -(_graphic.ContentSize.Width * 0.5f))
            {
                _graphic.PositionX = _graphic2.PositionX + _graphic.ContentSize.Width;
            }
            if (_graphic2.PositionX <= -(_graphic2.ContentSize.Width * 0.5f))
            {
                _graphic2.PositionX = _graphic.PositionX + _graphic2.ContentSize.Width;
            }
        }

    }
}
