using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "ScriptableObjects/GameConfig", order = 1)]
    public class GameConfig : ScriptableObject
    {
        [Header("Planets")]
        public int totalNumberOfPlanetsOnMap = 1;
        public float planetMinRadius = 1.5f;
        public float planetMaxRadius = 2.5f;

        [Header("Optimization")]
        [Tooltip("Maximum tries for generating single planet on random map position without intersecting with other planets." +
            " If max tries is exceeded we skip iteration and generate less planets than expected")]
        public int maxPlanetGenerationTries = 50;
    }
}

