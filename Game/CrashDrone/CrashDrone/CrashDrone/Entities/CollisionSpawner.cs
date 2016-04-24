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

        private float _timeSinceLastBatterySpawn;
        public float TimeInbetweenBatterySpawns
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

            _timeSinceLastBatterySpawn = 0.0f;
            TimeInbetweenBatterySpawns = 15f;

        }

        public void Activity(float frameTime)
        {
            _timeSinceLastBirdSpawn += frameTime;
            _timeSinceLastGroundUnitSpawn += frameTime;
            _timeSinceLastBatterySpawn += frameTime;


            if (_timeSinceLastBirdSpawn > TimeInbetweenBirdSpawns)
            {
                _timeSinceLastBirdSpawn = 0.0f;
                SpawnBird();
            }

            if (_timeSinceLastGroundUnitSpawn > TimeInbetweenGroundUnitSpawns)
            {
                _timeSinceLastGroundUnitSpawn = 0.0f;
                SpawnGroundUnit();
            }

            if (_timeSinceLastBatterySpawn > TimeInbetweenBatterySpawns)
            {
                _timeSinceLastBatterySpawn = 0.0f;
                SpawnBattery();
            }

        }

        private void SpawnBattery()
        {
            TimeInbetweenBatterySpawns = CCRandom.GetRandomFloat(15f, 45f);

            var collisionEntity = new Battery();
            collisionEntity.PositionX = _layer.VisibleBoundsWorldspace.MaxX + collisionEntity.GraphicWidth * 0.5f;
            collisionEntity.PositionY = CCRandom.GetRandomFloat(_layer.VisibleBoundsWorldspace.MaxY * 0.2f, _layer.VisibleBoundsWorldspace.MaxY * 0.7f);

            if (EntitySpawned != null)
            {
                EntitySpawned(collisionEntity);
            }
        }

        private void SpawnBird()
        {
            TimeInbetweenBirdSpawns = CCRandom.GetRandomFloat(1.6f, 5f);

            var collisionEntity = new Bird();
            collisionEntity.PositionX = _layer.VisibleBoundsWorldspace.MaxX + collisionEntity.GraphicWidth * 0.5f;
            collisionEntity.PositionY = CCRandom.GetRandomFloat(_layer.VisibleBoundsWorldspace.MaxY * 0.2f, _layer.VisibleBoundsWorldspace.MaxY * 0.7f);

            if (EntitySpawned != null)
            {
                EntitySpawned(collisionEntity);
            }
        }

        private void SpawnGroundUnit()
        {
            TimeInbetweenGroundUnitSpawns = CCRandom.GetRandomFloat(5f, 35f);
            CollisionEntity collisionEntity = null;

            var randomFloat = CCRandom.GetRandomFloat(0.0f, 3.0f);
            if (randomFloat > 2.0f)
            {
                collisionEntity = new Tree();
            }
            else if (randomFloat > 1.0f)
            {
                collisionEntity = new House();
            }
            else
            {
                collisionEntity = new Radar();
            }


            collisionEntity.Position = new CCPoint(_layer.VisibleBoundsWorldspace.MaxX + collisionEntity.GraphicWidth * 0.5f, _layer.VisibleBoundsWorldspace.MinY);


            if (EntitySpawned != null)
            {
                EntitySpawned(collisionEntity);
            }
        }

    }
}
