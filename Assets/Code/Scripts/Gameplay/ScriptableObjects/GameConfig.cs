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
    }
}

