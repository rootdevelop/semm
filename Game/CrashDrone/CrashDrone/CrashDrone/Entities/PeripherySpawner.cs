using CocosSharp;
using System;

namespace CrashDrone.Common.Entities
{
    public class PeripherySpawner
    {
        private PeripheryLayer _layer;

        public Action<PeripheryEntity> EntitySpawned; 

        public PeripherySpawner(PeripheryLayer periphery)
        {
            _layer = periphery;
            Spawn();
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
