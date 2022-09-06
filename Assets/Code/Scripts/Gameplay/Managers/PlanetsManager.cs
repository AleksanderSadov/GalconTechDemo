using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public class PlanetsManager : MonoBehaviour
    {
        public Planet planetPrefab;
        public Transform playablePlane;
        public PlanetsFindSpawnPosition planetsFindSpawnPosition;

        public void GenerateAllPlanets(
            int numberOfPlanetsRequired,
            float minPlanetScale,
            float maxPlanetScale,
            int maxTries
        )
        {
            planetsFindSpawnPosition.Init(
                planetPrefab.GetRadius(),
                minPlanetScale,
                maxPlanetScale,
                1 << planetPrefab.gameObject.layer,
                playablePlane
            );

            PlanetSpawner planetSpawner = new PlanetSpawner();

            int generatedPlanetsTriedCount = 0;
            int generatedPlanetsSuccessCount = 0;
            while (generatedPlanetsTriedCount < numberOfPlanetsRequired && planetsFindSpawnPosition.canTryMore)
            {
                int triesCount = 0;
                bool isSpawnFound = false;
                Vector3 spawnPosition = Vector3.zero;
                while (!isSpawnFound && planetsFindSpawnPosition.canTryMore && triesCount < maxTries)
                {
                    isSpawnFound = planetsFindSpawnPosition.GetNextPlanetSpawnPosition(out spawnPosition);
                    triesCount++;
                }

                if (isSpawnFound)
                {
                    planetSpawner.SpawnPlanet(
                        planetPrefab,
                        spawnPosition,
                        minPlanetScale,
                        maxPlanetScale
                    );

                    generatedPlanetsSuccessCount++;
                }

                generatedPlanetsTriedCount++;
            }

            if (generatedPlanetsSuccessCount < numberOfPlanetsRequired)
            {
                Debug.Log(
                    "Cannot fit all planets on map with current generation method\n" +
                    "Number of generated planets: " + generatedPlanetsSuccessCount + "\n" +
                    "Number of required planets: " + numberOfPlanetsRequired + "\n" +
                    "Max tries: " + maxTries
                );
            }

            planetsFindSpawnPosition.Free();
        }
    }
}

