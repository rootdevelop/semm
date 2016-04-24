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
        private CollisionLayer _layer;

        private bool _isSpawning;

        private float _timeSinceLastBirdSpawn;
        public float TimeInbetweenBirdSpawns
        {
            get;
            set;
        }

        private float _timeSinceLastGroundUnitSpawn;
        public float TimeInbetweenGroundUnitSpawns
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

            _timeSinceLastGroundUnitSpawn = 0.0f;
            TimeInbetweenGroundUnitSpawns = 8f;
        }

        public void Activity(float frameTime)
        {
            _timeSinceLastBirdSpawn += frameTime;
            _timeSinceLastGroundUnitSpawn += frameTime;


            if (_timeSinceLastBirdSpawn > TimeInbetweenBirdSpawns)
            {
                SpawnBird();
            }

            if (_timeSinceLastGroundUnitSpawn > TimeInbetweenGroundUnitSpawns)
            {
                _timeSinceLastGroundUnitSpawn = 0.0f;
                SpawnGroundUnit();
            }
            
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

        private void SpawnGroundUnit()
        {
            TimeInbetweenGroundUnitSpawns = CCRandom.GetRandomFloat(5f, 35f);
            CollisionEntity collisionEntity = null;
            if (CCRandom.Float_0_1() > 0.5f)
            {
                collisionEntity = new Tree();
            }
            else
            {
                collisionEntity = new House();
            }


            collisionEntity.Position = new CCPoint(_layer.VisibleBoundsWorldspace.MaxX + collisionEntity.GraphicWidth * 0.5f, _layer.VisibleBoundsWorldspace.MinY);


            if (EntitySpawned != null)
            {
                EntitySpawned(collisionEntity);
            }
        }

    }
}
