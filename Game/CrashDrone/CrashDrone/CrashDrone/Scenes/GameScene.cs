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
            

            this.AddLayer(new CollisionLayer());
            this.AddLayer(new HudLayer());
            this.AddLayer(new DroneLayer());
        }

        private void CreatePeripherySpawner()
        {
            _peripherySpawner = new PeripherySpawner(_peripheryLayer);
            _peripherySpawner.EntitySpawned += HandlePeripheryAdded;
        }


        private void HandlePeripheryAdded(PeripheryEntity perEntity)
        {
            _peripheryLayer.AddChild(perEntity);
        }

    }
}
