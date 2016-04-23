using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CocosSharp;

namespace CrashDrone.Common.Entities
{
    class NavigateButton : CCNode
    {
        public Action Action;
        public CCSprite graphic { get; set; }
        public int moveDistance { get; set; }

        public NavigateButton(string name, int dy, Action action)
        {
            this.Action = action;
            this.moveDistance = dy;
            CreateSpriteGraphic(name);
            var touchListener = new CCEventListenerTouchAllAtOnce();
            touchListener.OnTouchesBegan = this.OnTouchesBegan;

            AddEventListener(touchListener, this);
        }

        private void CreateSpriteGraphic(string name)
        {
            graphic = new CCSprite(string.Format("/Asset/Content/Images/button_{0}.png", name));
            graphic.Scale = 0.75f;
            graphic.IsAntialiased = false;
            AddChild(graphic);
        }

        void OnTouchesBegan(List<CCTouch> touches, CCEvent touchEvent)
        {
            
            
            if (touches.Count != 0)
            {
                var button = (NavigateButton)touchEvent.CurrentTarget;
                var buttonClicked = button.graphic.BoundingBoxTransformedToWorld.ContainsPoint(touches.First().Location);
                if (buttonClicked)
                {
                    Action();
                    touchEvent.StopPropogation();
                }
            }
        }
    }
}
