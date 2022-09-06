using System.Collections;
using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public class PlanetsGenerator : MonoBehaviour
    {
        [SerializeField]
        private PlanetsGenerationMethod planetsGeneration;

        private void Awake()
        {
            planetsGeneration = GetComponent<PlanetsGenerationMethod>();
        }

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
        }
    }
}

