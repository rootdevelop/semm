using CocosSharp;
using System;

namespace CrashDrone.Common.Entities
{
    public class PeripherySpawner
    {
        private PeripheryLayer _layer;
        private bool _isSpawning;

        public Action<PeripheryEntity> EntitySpawned; 

        public PeripherySpawner(PeripheryLayer periphery)
        {
            _isSpawning = false;
            _layer = periphery;
        }

        public void Activity(float frameTime)
        {
            if (!_isSpawning)
            {
                _isSpawning = true;
                Spawn();
            }

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

            if (EntitySpawned != null)
            {
                EntitySpawned(peripheryEntity);
            }
        }

    }
}
