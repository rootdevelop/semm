using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrashDrone.Common.Entities
{
    public class CollisionSpawner
    {
        const float minimumWait = 0.5f;
        float _timeSinceLastSpawn;
        private CollisionLayer _layer;
        private bool _isSpawning;

        public Action<CollisionEntity> EntitySpawned;

        public CollisionSpawner(CollisionLayer periphery)
        {
            _timeSinceLastSpawn = 0.0f;
            _isSpawning = false;
            _layer = periphery;
        }

        public void Activity(float frameTime)
        {
            if (!_isSpawning)
            {
                _isSpawning = true;
                SpawnBird();
            }

            //if (IsSpawning)
            //{
            //    SpawningActivity(frameTime);

            //    SpawnReductionTimeActivity(frameTime);
            //}
        }
        private void SpawnBird()
        {
            var collisionEntity = new Bird();

            if (EntitySpawned != null)
            {
                EntitySpawned(collisionEntity);
            }
        }
    }
}
