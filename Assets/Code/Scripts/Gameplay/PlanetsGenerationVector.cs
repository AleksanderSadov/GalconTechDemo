using System.Collections.Generic;
using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public class PlanetsGenerationVector : MonoBehaviour, IPlanetsGeneration
    {
        readonly Vector3 PLANE_DEFAULT_SIZE = new Vector3(10f, 0f, 10f);

        public float spawnPointStep = 0.1f;

        [SerializeField]
        private Transform playablePlane;
        [SerializeField]
        private Planet planetPrefab;

        public Planet GenerateNextPlanet(float minPlanetRadius, float maxPlanetRadius)
        {
            Vector3 startingPoint = playablePlane.position;

            Vector3 randomVector = GetRandomVector(
                playablePlane.localScale.x * PLANE_DEFAULT_SIZE.x / 2 - maxPlanetRadius,
                playablePlane.localScale.z * PLANE_DEFAULT_SIZE.z / 2 - maxPlanetRadius
            );
            Vector3 spawnPoint = startingPoint + randomVector;

            return TrySpawnPlanet(spawnPoint, minPlanetRadius, maxPlanetRadius);
        }

        private Planet TrySpawnPlanet(Vector3 currentPlanetCenter, float minPlanetRadius, float maxPlanetRadius)
        {
            Collider[] hitColliders = Physics.OverlapSphere(currentPlanetCenter, maxPlanetRadius * 4, 1 << planetPrefab.gameObject.layer);

            float maxAllowedRadius = maxPlanetRadius;
            foreach (Collider collider in hitColliders)
            {
                Planet collidingPlanet = collider.GetComponent<Planet>();

                if (collidingPlanet == null)
                {
                    continue;
                }

                float collidingPlanetRadius = collidingPlanet.GetRadius();
                float minRequiredDistance = (minPlanetRadius + collidingPlanetRadius) * 2;
                float distanceBetweenPlanets = Vector3.Distance(currentPlanetCenter, collidingPlanet.transform.position);

                if (distanceBetweenPlanets < minRequiredDistance)
                {
                    return null;
                }

                float allowedRadius = (distanceBetweenPlanets - (2 * collidingPlanetRadius)) / 2;

                if (allowedRadius < maxAllowedRadius)
                {
                    maxAllowedRadius = allowedRadius;
                }
            }

            float currentPlanetRandomRadius = Random.Range(minPlanetRadius, maxAllowedRadius);

            Planet planet = Instantiate(
                planetPrefab,
                currentPlanetCenter,
                planetPrefab.transform.rotation,
                null
            );

            planet.transform.localScale = Vector3.one * currentPlanetRandomRadius;

            return planet;
        }
        
        private Vector3 GetRandomVector(float maxWidth, float maxHeight)
        {
            float randomWidth = Random.Range(-maxWidth, maxWidth);
            randomWidth = Mathf.Floor(randomWidth / spawnPointStep) * spawnPointStep;
            float randomHeight = Random.Range(-maxHeight, maxHeight);
            randomHeight = Mathf.Floor(randomHeight / spawnPointStep) * spawnPointStep;

            Vector3 randomVector = new Vector3(randomWidth, randomHeight, 0.0f);

            return randomVector;
        }
    }
}

