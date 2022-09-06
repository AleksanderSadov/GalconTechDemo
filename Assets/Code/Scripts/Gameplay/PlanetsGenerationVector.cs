using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public class PlanetsGenerationVector : MonoBehaviour, IPlanetsGeneration
    {
        [SerializeField]
        private Transform playablePlane;
        [SerializeField]
        private Planet planetPrefab;
        
        public Planet GenerateNextPlanet(Planet previousPlanet, float minPlanetRadius, float maxPlanetRadius)
        {
            Vector3 startingPoint = previousPlanet != null
                ? previousPlanet.transform.position
                : playablePlane.transform.position;

            float previousPlanetRadius = previousPlanet != null ? previousPlanet.GetRadius() : 0f;
            float currentPlanetRadius = Random.Range(minPlanetRadius, maxPlanetRadius);
            float randomEulerAngle = Random.Range(0f, 360f);
            float minDistanceBetweenPlanets = (previousPlanetRadius + currentPlanetRadius) * 2;

            Vector3 randomVector = GetRandomVector(randomEulerAngle, minDistanceBetweenPlanets);
            Vector3 spawnPoint = startingPoint + randomVector;

            return Instantiate(
                planetPrefab, 
                spawnPoint,
                planetPrefab.transform.rotation,
                null
            );
        }
        
        private Vector3 GetRandomVector(float angle, float magnitude)
        {
            Quaternion rotation  = Quaternion.AngleAxis(angle, Vector3.forward);
            Vector3 XYZdirection = rotation * new Vector3(magnitude,0.0f,0.0f);
            return XYZdirection;
        }
    }
}

