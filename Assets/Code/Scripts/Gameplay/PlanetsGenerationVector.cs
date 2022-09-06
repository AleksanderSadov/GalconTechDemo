using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public class PlanetsGenerationVector : MonoBehaviour, IPlanetsGeneration
    {
        readonly Vector3 PLANE_DEFAULT_SIZE = new Vector3(10f, 0f, 10f);

        [SerializeField]
        private Transform playablePlane;
        [SerializeField]
        private Planet planetPrefab;
        
        public Planet GenerateNextPlanet(float minPlanetRadius, float maxPlanetRadius)
        {
            Vector3 startingPoint = playablePlane.position;

            float currentPlanetRadius = Random.Range(minPlanetRadius, maxPlanetRadius);
            Vector3 randomVector = GetRandomVector(
                playablePlane.localScale.x * PLANE_DEFAULT_SIZE.x / 2,
                playablePlane.localScale.z * PLANE_DEFAULT_SIZE.z / 2
            );
            Vector3 spawnPoint = startingPoint + randomVector;

            if (IsIntersectingWithAnotherPlanet(spawnPoint, currentPlanetRadius, maxPlanetRadius))
            {
                return null;
            }

            Planet planet = Instantiate(
                planetPrefab,
                spawnPoint,
                planetPrefab.transform.rotation,
                null
            );

            planet.transform.localScale = Vector3.one * currentPlanetRadius;

            return planet;
        }

        public bool IsIntersectingWithAnotherPlanet(Vector3 currentPlanetCenter, float currentPlanetRadius, float maxPlanetRadius)
        {
            Collider[] hitColliders = Physics.OverlapSphere(currentPlanetCenter, maxPlanetRadius * 4, 1 << planetPrefab.gameObject.layer);

            foreach (Collider collider in hitColliders)
            {
                Planet collidingPlanet = collider.GetComponent<Planet>();

                if (collidingPlanet == null)
                {
                    continue;
                }

                float collidingPlanetRadius = collidingPlanet.GetRadius();
                float minRequiredDistance = (currentPlanetRadius + collidingPlanetRadius) * 2;
                float distanceBetweenPlanets = Vector3.Distance(currentPlanetCenter, collidingPlanet.transform.position);

                if (distanceBetweenPlanets < minRequiredDistance)
                {
                    return true;
                }
            }

            return false;
        }
        
        private Vector3 GetRandomVector(float maxWidth, float maxHeight)
        {
            float randomWidth = Random.Range(-maxWidth, maxWidth);
            float randomHeight = Random.Range(-maxHeight, maxHeight);

            Vector3 randomVector = new Vector3(randomWidth, randomHeight, 0.0f);

            return randomVector;
        }
    }
}

