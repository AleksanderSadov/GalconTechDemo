using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public class GameManager : MonoBehaviour
    {
        private void Start()
        {
            GameModel gameModel = FindObjectOfType<GameModel>();
            GameStartedEvent onGameStartedEvent = Events.OnGameStartedEvent;
            onGameStartedEvent.gameConfig = gameModel.gameConfig;
            EventsManager.Broadcast(onGameStartedEvent);
        }
    }
}

