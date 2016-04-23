using CocosSharp;
using System;

namespace CrashDrone.Common.Entities
{
    public class PeripherySpawner
    {
        private int _height;

        public Action<PeripheryEntity> EntitySpawned; 

        public PeripherySpawner( int height)
        {
            _height = height;
        }




        private Spawn()
        {
            var peripheryEntity = new Forest();

            peripheryEntity.PositionX = 0;
            peripheryEntity.PositionY = height-forest.;

            if (EntitySpawned != null)
            {
                EntitySpawned(peripheryEntity);
            }
        }

    }
}
