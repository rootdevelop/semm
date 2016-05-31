using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CocosSharp;
using CrashDrone.Common.Entities;

namespace CrashDrone.Common
{
    class GameScene : CCScene
    {
        private Drone _drone;
        private DroneLayer _droneLayer;
        private HudLayer _hudLayer;
        private PeripheryLayer _peripheryLayer;
        private CollisionLayer _collisionLayer;
        private PeripherySpawner _peripherySpawner;
        private CollisionSpawner _collisionSpawner;
        private List<PeripheryEntity> _peripheryList;
        private List<CollisionEntity> _collisionList;
        private List<CCLabel> _collisionLabelList;

        public GameScene(CCGameView gameview) : base(gameview)
        {
            Init();
        }

        private void Init()
        {
            this.AddLayer(new BackgroundLayer());
            _collisionLabelList = new List<CCLabel>();
            _peripheryLayer = new PeripheryLayer();
            CreatePeripherySpawner();
            this.AddLayer(_peripheryLayer);
            _peripheryList = new List<PeripheryEntity>();
            _collisionLayer = new CollisionLayer();
            CreateCollisionSpawner();
            this.AddLayer(_collisionLayer);
            _collisionList = new List<CollisionEntity>();
            _droneLayer = new DroneLayer();
            _drone = _droneLayer.Drone;
            this._hudLayer = new HudLayer(_droneLayer.MoveUp, _droneLayer.MoveDown);
            this.AddLayer(_hudLayer);
            this.AddLayer(_droneLayer);
            Schedule(Activity);
        }

        private void CreateCollisionSpawner()
        {
            _collisionSpawner = new CollisionSpawner(_collisionLayer);
            _collisionSpawner.EntitySpawned += HandleCollisionAdded;
        }

        private void CreatePeripherySpawner()
        {
            _peripherySpawner = new PeripherySpawner(_peripheryLayer);
            _peripherySpawner.EntitySpawned += HandlePeripheryAdded;
        }
        
        private void HandleCollisionAdded(CollisionEntity colEntity)
        {
            _collisionList.Add(colEntity);
            _collisionLayer.AddChild(colEntity);
        }

        private void HandlePeripheryAdded(PeripheryEntity perEntity)
        {
            _peripheryList.Add(perEntity);
            _peripheryLayer.AddChild(perEntity);
        }

        private void Activity(float frameTimeInSeconds)
        {
            foreach (var pe in _peripheryList)
            {
                pe.Activity(frameTimeInSeconds);
            }
            foreach (var lbl in _collisionLabelList)
            {
                if (lbl.Opacity >= 5)
                {
                    lbl.Opacity -= 5;
                }
                else
                {
                    lbl.Opacity = 0;
                }
            }
            var toRemove = _collisionLabelList.Where(l => l.Opacity == 0).ToList();
            foreach (var lb in toRemove)
            {
                _collisionLabelList.Remove(lb);
                _hudLayer.RemoveChild(lb);
            }

            foreach (var co in _collisionList)
            {
                co.Activity(frameTimeInSeconds);
                if (co.CollisionBounds.IntersectsRect(_drone.CollisionBounds))
                {
                    var collisionCenter = co.CollisionBounds.Intersection(_drone.CollisionBounds).Center;
                    int energyChange = co.Collide();
                    if (energyChange < 0)
                    {
                        _hudLayer.AddScore(1);
                        _hudLayer.RemoveEnergy(energyChange);
                        var label = new CCLabel(string.Format("{0}", energyChange), "Fonts/MarkerFelt", 22, CCLabelFormat.SpriteFont);
                        label.Position = collisionCenter.Offset(0, -150f);
                        label.Color = CCColor3B.Red;
                        _hudLayer.AddChild(label);
                        _collisionLabelList.Add(label);
                    }
                    else if (energyChange > 0 && !_droneLayer.crashed)
                    {
                        _hudLayer.AddEnergy(energyChange);
                        var label = new CCLabel(string.Format("+{0}", energyChange), "Fonts/MarkerFelt", 22, CCLabelFormat.SpriteFont);
                        label.Color = CCColor3B.Green;
                        label.Position = collisionCenter.Offset(0, -150f);
                        _hudLayer.AddChild(label);
                        _collisionLabelList.Add(label);
                    }
                    if (_hudLayer.energy <= 0)
                    {
                        _droneLayer.Crash();
                    }
                }
            }
            
            _peripherySpawner.Activity(frameTimeInSeconds);
            _collisionSpawner.Activity(frameTimeInSeconds);
        }
    }
}
