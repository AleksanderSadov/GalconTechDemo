using System.Collections;
using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public class PlanetsGenerator : MonoBehaviour
    {
        [SerializeField]
        private IPlanetsGeneration planetsGeneration;

        private void Start()
        {
            planetsGeneration = GetComponent<IPlanetsGeneration>();
        }

        public IEnumerator GenerateAllPlanets(
            int numberOfPlanets,
            float minPlanetRadius,
            float maxPlanetRadius
        )
        {
            int generatedPlanetsCount = 0;
            while (generatedPlanetsCount < numberOfPlanets)
            {
                planetsGeneration.GenerateNextPlanet(
                    null,
                    minPlanetRadius,
                    maxPlanetRadius
                );
                generatedPlanetsCount++;
                yield return null;
            }
        }
    }
}

