using CocosSharp;
using System;

namespace CrashDrone.Common.Entities
{
    public class PeripherySpawner
    {
        private PeripheryLayer _layer;
        private bool IsSpawning;

        public Action<PeripheryEntity> EntitySpawned; 

        public PeripherySpawner(PeripheryLayer periphery)
        {
            IsSpawning = true;
            _layer = periphery;
            Spawn();
        }

        public void Activity(float frameTime)
        {
            //if (IsSpawning)
            //{
            //    SpawningActivity(frameTime);

            //    SpawnReductionTimeActivity(frameTime);
            //}
        }

        private void SpawningActivity(float frameTime)
        {
            //timeSinceLastSpawn += frameTime;

            //if (timeSinceLastSpawn > TimeInbetweenSpawns)
            //{
            //    timeSinceLastSpawn -= TimeInbetweenSpawns;

            //    Spawn();
            //}
        }

        private void Spawn()
        {
            var peripheryEntity = new Forest();

            peripheryEntity.PositionX = 0;
            peripheryEntity.PositionY = _layer.ContentSize.Height - peripheryEntity.SpriteFrame.ContentSize.Height;

            if (EntitySpawned != null)
            {
                EntitySpawned(peripheryEntity);
            }
        }

    }
}
