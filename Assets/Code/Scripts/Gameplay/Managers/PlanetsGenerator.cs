using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public class PlanetsGenerator : MonoBehaviour
    {
        public PlanetsGenerationMethod planetsGeneration;

        public void GenerateAllPlanets(
            int numberOfPlanetsRequired,
            float minPlanetScale,
            float maxPlanetScale,
            int maxTries
        )
        {
            planetsGeneration.Init(minPlanetScale, maxPlanetScale);

            int generatedPlanetsTriedCount = 0;
            int generatedPlanetsSuccessCount = 0;

            while (generatedPlanetsTriedCount < numberOfPlanetsRequired && planetsGeneration.canTryMore)
            {
                int triesCount = 0;
                Planet lastGeneratedPlanet = null;

                while (lastGeneratedPlanet == null && planetsGeneration.canTryMore && triesCount < maxTries)
                {
                    lastGeneratedPlanet = planetsGeneration.GenerateNextPlanet();
                    triesCount++;
                }

                if (lastGeneratedPlanet != null)
                {
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

            planetsGeneration.Free();
        }
    }
}

