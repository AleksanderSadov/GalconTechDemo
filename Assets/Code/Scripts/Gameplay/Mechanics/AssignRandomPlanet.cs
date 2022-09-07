using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public class AssignRandomPlanet : MonoBehaviour
    {
        private GameConfig gameConfig;
        private PlanetsModel planetsModel;
        private TeamsModel teamsModel;

        private void OnEnable()
        {
            EventsManager.AddListener<PlanetsGeneratedEvent>(OnPlanetsGenerated);
        }

        private void Awake()
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            gameConfig = gameManager.gameConfig;
            planetsModel = gameManager.planetsModel;
            teamsModel = gameManager.teamsModel;
        }

        private void OnDisable()
        {
            EventsManager.RemoveListener<PlanetsGeneratedEvent>(OnPlanetsGenerated);
        }

        private void OnPlanetsGenerated(PlanetsGeneratedEvent evt)
        {
            TeamMember player = teamsModel.player;
            TeamMember enemy = teamsModel.enemy;
            AssignToRandomPlanet(player);
            AssignToRandomPlanet(enemy);
        }

        private void AssignToRandomPlanet(TeamMember teamMember)
        {
            Planet planet = planetsModel.GetRandomNotControlledPlanet();
            planet.AssignTo(teamMember);
            planet.currentShipsCount = gameConfig.shipsOnFirstPlanet;
        }
    }
}

