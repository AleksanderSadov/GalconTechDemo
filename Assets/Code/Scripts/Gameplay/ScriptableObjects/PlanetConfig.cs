using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    [CreateAssetMenu(fileName = "PlanetConfig", menuName = "ScriptableObjects/PlanetConfig", order = 2)]
    public class PlanetConfig : ScriptableObject
    {
        public int minShipsOnStart = 1;
        public int maxShipsOnStart = 50;
        public int shipsGenerationSpeed = 5;
    }
}

