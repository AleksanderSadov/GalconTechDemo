using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public interface ISpawnPlanet
    {
        public Planet SpawnPlanet(
            Planet planetPrefab,
            Vector3 spawnPosition,
            float minPlanetScale,
            float maxPlanetScale
        );
    }
}

