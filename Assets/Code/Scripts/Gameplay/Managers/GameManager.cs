using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public class GameManager : MonoBehaviour
    {
        public GameConfig gameConfig;
        public PlanetsModel planetsModel;
        public TeamsModel teamsModel;

        private void Start()
        {
            GameStartedEvent onGameStartedEvent = Events.OnGameStartedEvent;
            onGameStartedEvent.gameConfig = gameConfig;
            EventsManager.Broadcast(onGameStartedEvent);
        }
    }
}

