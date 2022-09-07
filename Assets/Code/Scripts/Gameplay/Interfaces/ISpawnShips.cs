using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public interface ISpawnShips
    {
        public Ship SpawnShip(Ship shipPrefab, Vector3 spawnPosition, Transform parent);
    }
}

