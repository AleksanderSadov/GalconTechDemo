using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public interface ISpawnShips
    {
        public Planet SpawnShip(
            Planet planetPrefab,
            Vector3 spawnPosition,
            float minPlanetScale,
            float maxPlanetScale,
            Transform parent
        );
    }
}

