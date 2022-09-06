using System.Collections;
using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public class PlanetsGenerator : MonoBehaviour
    {
        [SerializeField]
        private IPlanetsGeneration planetsGeneration;

        private void Awake()
        {
            planetsGeneration = GetComponent<IPlanetsGeneration>();
        }

        public void GenerateAllPlanets(
            int numberOfPlanets,
            float minPlanetRadius,
            float maxPlanetRadius,
            int maxTries
        )
        {
            int generatedPlanetsTriedCount = 0;
            while (generatedPlanetsTriedCount < numberOfPlanets)
            {
                int triesCount = 0;
                Planet lastGeneratedPlanet = null;

                while (lastGeneratedPlanet == null && triesCount < maxTries)
                {
                    lastGeneratedPlanet = planetsGeneration.GenerateNextPlanet(minPlanetRadius, maxPlanetRadius);
                    triesCount++;
                }

                generatedPlanetsTriedCount++;
            }
        }
    }
}

