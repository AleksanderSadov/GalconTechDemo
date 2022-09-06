using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public class GameManager : MonoBehaviour
    {
        public GameConfig gameConfig;
        public PlanetsModel planetsModel;
        public TeamsModel teamsModel;

        private void OnEnable()
        {
            EventsManager.AddListener<PlanetsGeneratedEvent>(OnPlanetsGenerated);
        }

        private void Start()
        {
            GameStartedEvent onGameStartedEvent = Events.OnGameStartedEvent;
            onGameStartedEvent.gameConfig = gameConfig;
            EventsManager.Broadcast(onGameStartedEvent);
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

