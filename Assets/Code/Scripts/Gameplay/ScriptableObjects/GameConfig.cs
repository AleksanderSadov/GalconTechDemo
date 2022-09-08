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

        [Header("Ships")]
        public int shipsMinOnPlanetStart = 1;
        public int shipsMaxOnPlanetStart = 50;
        [Tooltip("Number of ships on your's and enemies' first planet when game starts")]
        public int shipsOnFirstControlledPlanet = 50;
        public int shipsGenerationSpeed = 5;
        [Tooltip("Percentage of ships deployed from planet when attacking another planet")]
        [Range(0.0f, 1.0f)]
        public float shipsAttackPercentage;
        public float shipsFlySpeed = 3.5f;
        public float shipsFlyAcceleration = 8f;

        [Header("Enemy")]
        [Tooltip("Cooldown between enemy decisions and attacks")]
        public float enemyDecisionsCooldown;
    }
}

