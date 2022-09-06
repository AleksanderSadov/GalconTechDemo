using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public interface IPlanetsFindSpawnPosition
    {
        public void Init(
            float planetBaseRadius,
            float minPlanetScale,
            float maxPlanetScale,
            LayerMask planetLayerMask,
            Transform playablePlane
        );
        public bool GetNextPlanetSpawnPosition(out Vector3 spawnPosition);
        public void Free();
    }
}

