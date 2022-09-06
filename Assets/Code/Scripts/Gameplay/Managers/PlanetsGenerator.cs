using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public class PlanetsGenerator : MonoBehaviour
    {
        public PlanetsGenerationMethod planetsGeneration;

        public void GenerateAllPlanets(
            int numberOfPlanets,
            float minPlanetScale,
            float maxPlanetScale,
            int maxTries
        )
        {
            planetsGeneration.Init(minPlanetScale, maxPlanetScale);

            int generatedPlanetsTriedCount = 0;
            while (generatedPlanetsTriedCount < numberOfPlanets)
            {
                int triesCount = 0;
                Planet lastGeneratedPlanet = null;

                while (lastGeneratedPlanet == null && triesCount < maxTries)
                {
                    lastGeneratedPlanet = planetsGeneration.GenerateNextPlanet();
                    triesCount++;
                }

                generatedPlanetsTriedCount++;
            }

            planetsGeneration.Free();
        }
    }
}

