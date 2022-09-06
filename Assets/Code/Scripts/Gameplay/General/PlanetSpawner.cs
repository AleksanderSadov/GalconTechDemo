using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public class PlanetSpawner : ISpawnPlanet
    {
        public Planet SpawnPlanet(
            Planet planetPrefab,
            Vector3 spawnPosition,
            float minPlanetScale,
            float maxPlanetScale,
            Transform parent
        )
        {
            float currentPlanetRandomScale = Random.Range(minPlanetScale, maxPlanetScale);

            Planet planet = Object.Instantiate(
                planetPrefab,
                spawnPosition,
                planetPrefab.transform.rotation,
                parent
            );

            planet.transform.parent = parent;
            planet.transform.localScale = Vector3.one * currentPlanetRandomScale;

            return planet;
        }
    }
}

