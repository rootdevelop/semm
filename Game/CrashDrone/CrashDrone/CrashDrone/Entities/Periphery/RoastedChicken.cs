using CocosSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrashDrone.Common.Entities
{
    public class RoastedChicken : PeripheryEntity
    {
        private CCSprite _graphic;


        public RoastedChicken()
        {
            this.Speed = 0.0f;
            InitGraphic();
        }

        private void InitGraphic()
        {
            _graphic = new CCSprite("/Assets/Content/Images/Periphery/roastedChicken.png");
            _graphic.IsAntialiased = false;
            AddChild(_graphic);
        }

       public override void Activity(float frameTimeInSeconds)
        {
        }
    }
}
