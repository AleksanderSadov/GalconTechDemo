using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public class ShipsSpawner : ISpawnShips
    {
        public Ship SpawnShip(Ship shipPrefab, Vector3 spawnPosition, Transform parent)
        {
            Ship ship = Object.Instantiate(
                shipPrefab,
                spawnPosition,
                shipPrefab.transform.rotation,
                parent
            );

            ship.transform.parent = parent;

            return ship;
        }
    }
}

