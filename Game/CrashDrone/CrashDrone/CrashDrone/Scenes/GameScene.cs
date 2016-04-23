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
        private PeripherySpawner _peripherySpawner;
        private List<PeripheryEntity> _peripheryList;
    
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


            this.AddLayer(new CollisionLayer());
            this.AddLayer(new DroneLayer());
            this.AddLayer(new HudLayer());
        }

        private void CreatePeripherySpawner()
        {
            _peripherySpawner = new PeripherySpawner(_peripheryLayer);
            _peripherySpawner.EntitySpawned += HandlePeripheryAdded;
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

            //spawner.Activity(frameTimeInSeconds);       
        }
    }
}
