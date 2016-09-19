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

        private float _secondsToMaximumValues;

        private bool _isSpawning;

        private float _timeSinceStart;

        private float _minimumBirdSpeed;

        private float _maximumBirdSpeed;

        private float _minimumTimeSinceLastBirdSpawn;

        private float _maximumTimeSinceLastBirdSpawn;

        private float _timeSinceLastBirdSpawn;
        public float TimeInbetweenBirdSpawns
        {
            get;
            set;
        }

        private float _minimumTimeSinceLastBatterySpawn;

        private float _maximumTimeSinceLastBatterySpawn;

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
            _secondsToMaximumValues = 300f;
            _timeSinceStart = 0.0f;
            _minimumTimeSinceLastBirdSpawn = 0.6f;
            _maximumTimeSinceLastBirdSpawn = 3f;
            _timeSinceLastBirdSpawn = 0.0f;
            _minimumBirdSpeed = 150f;
            _maximumBirdSpeed = 700f;
            _isSpawning = false;
            _layer = periphery;
            TimeInbetweenBirdSpawns = 1.0f;

            _timeSinceLastGroundUnitSpawn = 0.0f;
            TimeInbetweenGroundUnitSpawns = 8f;

            _timeSinceLastBatterySpawn = 0.0f;
            _minimumTimeSinceLastBatterySpawn = 15f;
            _maximumTimeSinceLastBatterySpawn = 45f;
            TimeInbetweenBatterySpawns = 15f;
        }

        public void Activity(float frameTime)
        {
            _timeSinceLastBirdSpawn += frameTime;
            _timeSinceLastGroundUnitSpawn += frameTime;
            _timeSinceLastBatterySpawn += frameTime;
            _timeSinceStart += frameTime;


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

            if (_timeSinceStart < _secondsToMaximumValues + 1f)
            {
                SetRandomizerFactors();
            }
        }

        private void SetRandomizerFactors()
        {
            _minimumBirdSpeed = 100f + GetMinBySecond(500f);
            _maximumBirdSpeed = 500f + GetMinBySecond(400f);
            _minimumTimeSinceLastBirdSpawn = 2f - GetMinBySecond(1.7f);
            _maximumTimeSinceLastBirdSpawn = 4f - GetMinBySecond(2.8f);
            _minimumTimeSinceLastBatterySpawn = 30f - GetMinBySecond(25f);
            _maximumTimeSinceLastBatterySpawn = 50f - GetMinBySecond(42f);
        }

        private float GetMinBySecond(float maxValue)
        {
            return Math.Min(maxValue, maxValue / _secondsToMaximumValues * _timeSinceStart);
        }

        private void SpawnBattery()
        {
            TimeInbetweenBatterySpawns = CCRandom.GetRandomFloat(_minimumTimeSinceLastBatterySpawn, _maximumTimeSinceLastBatterySpawn);

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
            TimeInbetweenBirdSpawns = CCRandom.GetRandomFloat(_minimumTimeSinceLastBirdSpawn, _maximumTimeSinceLastBirdSpawn);

            var collisionEntity = new Bird(CCRandom.GetRandomFloat(_minimumBirdSpeed, _maximumBirdSpeed));
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
