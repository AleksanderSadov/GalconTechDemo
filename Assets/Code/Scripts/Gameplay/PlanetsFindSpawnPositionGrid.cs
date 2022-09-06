using System.Collections.Generic;
using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public class PlanetsFindSpawnPositionGrid : PlanetsFindSpawnPosition
    {
        [System.Serializable]
        private class GridPoint
        {
            public float x;
            public float y;
            public bool isFree = false;

            public GridPoint(float x, float y, bool isFree)
            {
                this.x = x;
                this.y = y;
                this.isFree = isFree;
            }
        }

        [Tooltip("Grid step")]
        public float gridStep = 0.1f;

        private List<GridPoint> spawnPoints;

        public override void Init(
            float planetBaseRadius,
            float minPlanetScale,
            float maxPlanetScale,
            LayerMask planetLayerMask,
            Transform playablePlane
        )
        {
            base.Init(
                planetBaseRadius,
                minPlanetScale,
                maxPlanetScale,
                planetLayerMask,
                playablePlane
            );

            GenerateSpawnPointsGrid(maxPlanetRadius);
        }

        public override bool GetNextPlanetSpawnPosition(out Vector3 spawnPosition)
        {
            List<GridPoint> freeSpawnPoints = spawnPoints.FindAll(p => p.isFree);
            if (freeSpawnPoints.Count > 0)
            {
                int randomIndex = Random.Range(0, freeSpawnPoints.Count);
                return TrySpawnPlanet(freeSpawnPoints[randomIndex], out spawnPosition);
            }
            else
            {
                canTryMore = false;
                spawnPosition = Vector3.zero;
                return false;
            }
        }

        public override void Free()
        {
            base.Free();
            spawnPoints = null;
        }

        private bool TrySpawnPlanet(GridPoint spawnPoint, out Vector3 spawnPosition)
        {
            Vector3 currentPlanetCenter = new Vector3(spawnPoint.x, spawnPoint.y, playablePlane.position.z);

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
                    spawnPoint.isFree = false;
                    spawnPosition = Vector3.zero;
                    return false;
                }

                float allowedRadius = (distanceBetweenPlanets - (2 * collidingPlanetRadius)) / 2;

                if (allowedRadius < maxAllowedRadius)
                {
                    maxAllowedRadius = allowedRadius;
                }
            }
            spawnPoint.isFree = false;

            spawnPosition = currentPlanetCenter;
            return true;
        }

        private void GenerateSpawnPointsGrid(float maxPlanetRadius)
        {
            spawnPoints = new List<GridPoint>();

            float planeWidth = playablePlane.localScale.x * PLANE_DEFAULT_SIZE.x;
            float planeHeight = playablePlane.localScale.z * PLANE_DEFAULT_SIZE.z;

            Vector3 topLeftPoint = new Vector3(
                playablePlane.position.x - planeWidth / 2 + maxPlanetRadius,
                playablePlane.position.y + planeHeight / 2 - maxPlanetRadius,
                playablePlane.position.z
            );
            Vector3 bottomRightPoint = new Vector3(
                playablePlane.position.x + planeWidth / 2 - maxPlanetRadius,
                playablePlane.position.y - planeHeight / 2 + maxPlanetRadius,
                playablePlane.position.z
            );

            float currentPositionX = topLeftPoint.x;
            float currentPositionY = topLeftPoint.y;

            int tryCount = 0;
            int maxGridTries = ((int) Mathf.Floor(planeWidth / gridStep)) * ((int)Mathf.Floor(planeHeight / gridStep));

            while (currentPositionY >= bottomRightPoint.y && tryCount < maxGridTries)
            {
                while (currentPositionX <= bottomRightPoint.x && tryCount < maxGridTries)
                {
                    spawnPoints.Add(new GridPoint(currentPositionX, currentPositionY, true));
                    currentPositionX += gridStep;
                    tryCount++;
                }

                currentPositionX = topLeftPoint.x;
                currentPositionY -= gridStep;
            }
        }
    }
}

