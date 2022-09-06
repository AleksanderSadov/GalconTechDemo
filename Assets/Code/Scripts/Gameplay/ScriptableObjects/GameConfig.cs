using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "ScriptableObjects/GameConfig", order = 1)]
    public class GameConfig : ScriptableObject
    {
        [Header("Planets")]
        public int planetsOnMap = 1;
        public float planetsMinScale = 1.5f;
        public float planetsMaxScale = 2.5f;

        [Header("Planets Optimization")]
        [Tooltip("Maximum tries for generating single planet on random map position without intersecting with other planets." +
            " If max tries is exceeded we skip iteration and generate less planets than expected")]
        public int planetsMaxGenerationTries = 50;

        [Header("Player")]
        public int playerShipsOnStart = 50;
    }
}

