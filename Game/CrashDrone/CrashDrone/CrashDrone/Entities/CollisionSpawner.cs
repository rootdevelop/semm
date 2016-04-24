using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CocosSharp;

namespace CrashDrone.Common.Entities
{
    public class CollisionSpawner
    {
        float _timeSinceLastBirdSpawn;
        private CollisionLayer _layer;
        private bool _isSpawning;

        public float TimeInbetweenBirdSpawns
        {
            get;
            set;
        }

        public Action<CollisionEntity> EntitySpawned;

        public CollisionSpawner(CollisionLayer periphery)
        {
            _timeSinceLastBirdSpawn = 0.0f;
            _isSpawning = false;
            _layer = periphery;
            TimeInbetweenBirdSpawns = 1.0f;
        }

        public void Activity(float frameTime)
        {
            _timeSinceLastBirdSpawn += frameTime;

            if (_timeSinceLastBirdSpawn > TimeInbetweenBirdSpawns)
            {
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
            TimeInbetweenBirdSpawns = CCRandom.GetRandomFloat(1.6f, 5f);
            _timeSinceLastBirdSpawn = 0.0f;

            var collisionEntity = new Bird();
            collisionEntity.PositionX = _layer.VisibleBoundsWorldspace.MaxX + collisionEntity.GraphicWidth * 0.5f;
            collisionEntity.PositionY = CCRandom.GetRandomFloat(_layer.VisibleBoundsWorldspace.MaxY * 0.2f, _layer.VisibleBoundsWorldspace.MaxY * 0.7f);

            if (EntitySpawned != null)
            {
                EntitySpawned(collisionEntity);
            }
            _isSpawning = false;
        }
    }
}
