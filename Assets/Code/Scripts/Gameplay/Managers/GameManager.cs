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
            planetsGenerator.GenerateAllPlanets(
                gameConfig.totalNumberOfPlanetsOnMap,
                gameConfig.planetMinScale,
                gameConfig.planetMaxScale,
                gameConfig.maxPlanetGenerationTries
            );
        }
    } 
}

