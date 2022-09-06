using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public class PlanetsGenerationVector : PlanetsGenerationMethod
    {
        public override Planet GenerateNextPlanet()
        {
            Vector3 startingPoint = playablePlane.position;

            Vector3 randomVector = GetRandomVector(
                playablePlane.localScale.x * PLANE_DEFAULT_SIZE.x / 2 - maxPlanetRadius,
                playablePlane.localScale.z * PLANE_DEFAULT_SIZE.z / 2 - maxPlanetRadius
            );
            Vector3 spawnPoint = startingPoint + randomVector;

            return TrySpawnPlanet(spawnPoint);
        }

        private Planet TrySpawnPlanet(Vector3 currentPlanetCenter)
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

            float currentPlanetRandomScale = Random.Range(minPlanetScale, maxPlanetScale);

            Planet planet = Instantiate(
                planetPrefab,
                currentPlanetCenter,
                planetPrefab.transform.rotation,
                null
            );

            planet.transform.localScale = Vector3.one * currentPlanetRandomScale;

            return planet;
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

