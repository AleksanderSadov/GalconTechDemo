using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public class PlanetsGenerationController : MonoBehaviour
    {
        public Transform planetsContainer;
        public Planet planetPrefab;
        public Transform playablePlane;
        public PlanetsFindSpawnPosition planetsFindSpawnPosition;

        private PlanetsModel planetsModel;

        private void Awake()
        {
            planetsModel = FindObjectOfType<GameManager>().planetsModel;
        }

        private void OnEnable()
        {
            EventsManager.AddListener<GameStartedEvent>(OnGameStarted);
        }

        private void OnDisable()
        {
            EventsManager.RemoveListener<GameStartedEvent>(OnGameStarted);
        }

        private void OnGameStarted(GameStartedEvent evt) => GenerateAllPlanets(evt.gameConfig);

        public void GenerateAllPlanets(GameConfig gameConfig)
        {
            planetsFindSpawnPosition.Init(
                planetPrefab.GetRadius(),
                gameConfig.planetsMinScale,
                gameConfig.planetsMaxScale,
                1 << planetPrefab.gameObject.layer,
                playablePlane
            );

            ISpawnPlanet planetSpawner = new PlanetSpawner();

            int generatedPlanetsTriedCount = 0;
            int generatedPlanetsSuccessCount = 0;
            while (generatedPlanetsTriedCount < gameConfig.planetsOnMap && planetsFindSpawnPosition.canTryMore)
            {
                int triesCount = 0;
                bool isSpawnFound = false;
                Vector3 spawnPosition = Vector3.zero;
                while (!isSpawnFound && planetsFindSpawnPosition.canTryMore && triesCount < gameConfig.planetsMaxGenerationTries)
                {
                    isSpawnFound = planetsFindSpawnPosition.GetNextPlanetSpawnPosition(out spawnPosition);
                    triesCount++;
                }

                if (isSpawnFound)
                {
                    Planet planet = planetSpawner.SpawnPlanet(
                        planetPrefab,
                        spawnPosition,
                        gameConfig.planetsMinScale,
                        gameConfig.planetsMaxScale,
                        planetsContainer
                    );
                    planetsModel.planets.Add(planet);

                    generatedPlanetsSuccessCount++;
                }

                generatedPlanetsTriedCount++;
            }

            if (generatedPlanetsSuccessCount < gameConfig.planetsOnMap)
            {
                Debug.Log(
                    "Cannot fit all planets on map with current generation method\n" +
                    "Number of generated planets: " + generatedPlanetsSuccessCount + "\n" +
                    "Number of required planets: " + gameConfig.planetsOnMap + "\n" +
                    "Max tries: " + gameConfig.planetsMaxGenerationTries
                );
            }

            planetsFindSpawnPosition.Free();

            EventsManager.Broadcast(Events.PlanetsGeneratedEvent);
        }
    }
}

