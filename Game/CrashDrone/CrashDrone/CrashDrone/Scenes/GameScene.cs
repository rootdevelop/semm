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
        private PeripheryLayer _peripheryLayer;
        private CollisionLayer _collisionLayer;
        private PeripherySpawner _peripherySpawner;
        private CollisionSpawner _collisionSpawner;
        private List<PeripheryEntity> _peripheryList;
        private List<CollisionEntity> _collisionList;

        public GameScene(CCGameView gameview) : base(gameview)
        {
            Init();
        }

        private void Init()
        {
            this.AddLayer(new BackgroundLayer());

            _peripheryLayer = new PeripheryLayer();
            CreatePeripherySpawner();
            this.AddLayer(_peripheryLayer);
            _peripheryList = new List<PeripheryEntity>();
            _collisionLayer = new CollisionLayer();
            CreateCollisionSpawner();
            this.AddLayer(_collisionLayer);
            var droneLayer = new DroneLayer();
            var hudLayer = new HudLayer(droneLayer.MoveUp, droneLayer.MoveDown);
            this.AddLayer(hudLayer);
            this.AddLayer(droneLayer);
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
            foreach (var co in _collisionList)
            {
                co.Activity(frameTimeInSeconds);
            }
            
            _peripherySpawner.Activity(frameTimeInSeconds);
            _collisionSpawner.Activity(frameTimeInSeconds);
        }
    }
}
