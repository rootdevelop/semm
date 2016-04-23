using CocosSharp;
using System;

namespace CrashDrone.Common.Entities
{
    public class PeripherySpawner
    {
        private PeripheryLayer _layer;
        private bool _forestSpawned;

        public Action<PeripheryEntity> EntitySpawned;


        float timeSinceLastCloudSpawn;
        public float TimeInbetweenCloudSpawns
        {
            get;
            set;
        }

        public PeripherySpawner(PeripheryLayer periphery)
        {
            _layer = periphery;

            TimeInbetweenCloudSpawns = 0.8f;
            timeSinceLastCloudSpawn = TimeInbetweenCloudSpawns;
        }

        public void Activity(float frameTime)
        {
            if (!_forestSpawned)
            {
                _forestSpawned = true;
                SpawnForest();
            }
            else
            {
                SpawningCloudActivity(frameTime);
            }
            
            //    SpawnReductionTimeActivity(frameTime);
            
        }

        private void SpawningCloudActivity(float frameTime)
        {
            timeSinceLastCloudSpawn += frameTime;

            if (timeSinceLastCloudSpawn > TimeInbetweenCloudSpawns)
            {
               timeSinceLastCloudSpawn -= TimeInbetweenCloudSpawns;

               SpawnCloud();
            }

            
        }

        private void SpawnForest()
        {
            var peripheryEntity = new Forest();

            if (EntitySpawned != null)
            {
                EntitySpawned(peripheryEntity);
            }
        }

        private void SpawnCloud()
        {
            TimeInbetweenCloudSpawns = CCRandom.GetRandomFloat(0.8f, 3f);

            var peripheryEntity = new Cloud();
            peripheryEntity.PositionX = _layer.VisibleBoundsWorldspace.MaxX + peripheryEntity.ContentSize.Width*0.5f;
            peripheryEntity.PositionY = CCRandom.GetRandomFloat(_layer.VisibleBoundsWorldspace.MaxY * 0.25f, _layer.VisibleBoundsWorldspace.MaxY * 0.8f);

            if (EntitySpawned != null)
            {
                EntitySpawned(peripheryEntity);
            }
        }

    }
}
