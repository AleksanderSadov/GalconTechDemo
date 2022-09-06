using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public class GameManager : MonoBehaviour
    {
        public GameConfig gameConfig;

        [SerializeField]
        private PlanetsGenerator planetsGenerator;
        
        private void Start()
        {
            StartCoroutine(planetsGenerator.GenerateAllPlanets(
                gameConfig.totalNumberOfPlanetsOnMap,
                gameConfig.planetMinRadius,
                gameConfig.planetMaxRadius
            ));
        }
    } 
}

