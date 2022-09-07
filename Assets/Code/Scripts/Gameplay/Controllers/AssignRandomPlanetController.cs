using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public class AssignRandomPlanetController : MonoBehaviour
    {
        private PlanetsModel planetsModel;
        private TeamsModel teamsModel;

        private void OnEnable()
        {
            EventsManager.AddListener<PlanetsGeneratedEvent>(OnPlanetsGenerated);
        }

        private void Awake()
        {
            planetsModel = FindObjectOfType<GameManager>().planetsModel;
            teamsModel = FindObjectOfType<GameManager>().teamsModel;
        }

        private void OnDisable()
        {
            EventsManager.RemoveListener<PlanetsGeneratedEvent>(OnPlanetsGenerated);
        }

        private void OnPlanetsGenerated(PlanetsGeneratedEvent evt) => AssignPlayerToRandomPlanet();

        private void AssignPlayerToRandomPlanet()
        {
            Planet playerPlanet = planetsModel.GetRandomPlanet();
            TeamMember player = teamsModel.player;
            playerPlanet.AssignTo(player);
            playerPlanet.currentShipsCount = player.shipsOnStart;
        }
    }
}

