using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public class AssignRandomPlanet : MonoBehaviour
    {
        private GameModel gameModel;

        private void OnEnable()
        {
            EventsManager.AddListener<PlanetsGeneratedEvent>(OnPlanetsGenerated);
        }

        private void Awake()
        {
            gameModel = FindObjectOfType<GameModel>();
        }

        private void OnDisable()
        {
            EventsManager.RemoveListener<PlanetsGeneratedEvent>(OnPlanetsGenerated);
        }

        private void OnPlanetsGenerated(PlanetsGeneratedEvent evt)
        {
            TeamMember player = gameModel.teamsModel.player;
            TeamMember enemy = gameModel.teamsModel.enemy;
            AssignToRandomPlanet(player);
            AssignToRandomPlanet(enemy);
        }

        private void AssignToRandomPlanet(TeamMember teamMember)
        {
            Planet planet = gameModel.planetsModel.GetRandomNotControlledPlanet();
            planet.AssignTo(teamMember);
            planet.currentShipsCount = gameModel.gameConfig.shipsOnFirstPlanet;
        }
    }
}

