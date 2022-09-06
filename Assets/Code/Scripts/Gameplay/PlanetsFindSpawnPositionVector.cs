using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public class PlanetsFindSpawnPositionVector : PlanetsFindSpawnPosition
    {
        public override bool GetNextPlanetSpawnPosition(out Vector3 spawnPosition)
        {
            Vector3 startingPoint = playablePlane.position;

            Vector3 randomVector = GetRandomVector(
                playablePlane.localScale.x * PLANE_DEFAULT_SIZE.x / 2 - maxPlanetRadius,
                playablePlane.localScale.z * PLANE_DEFAULT_SIZE.z / 2 - maxPlanetRadius
            );
            Vector3 currentPlanetCenter = startingPoint + randomVector;

            return TrySpawnPlanet(currentPlanetCenter, out spawnPosition);
        }

        private bool TrySpawnPlanet(Vector3 currentPlanetCenter, out Vector3 spawnPosition)
        {
            Collider[] hitColliders = Physics.OverlapSphere(currentPlanetCenter, maxPlanetRadius * 4, planetLayerMask);

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
                    spawnPosition = Vector3.zero;
                    return false;
                }

                float allowedRadius = (distanceBetweenPlanets - (2 * collidingPlanetRadius)) / 2;

                if (allowedRadius < maxAllowedRadius)
                {
                    maxAllowedRadius = allowedRadius;
                }
            }

            spawnPosition = currentPlanetCenter;
            return true;
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

