using System.Collections.Generic;
using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public class GameManager : MonoBehaviour
    {
        private GameModel gameModel;

        private void Awake()
        {
            gameModel = FindObjectOfType<GameModel>();
        }

        private void OnEnable()
        {
            EventsManager.AddListener<PlanetCapturedEvent>(OnPlanetCaptured);
        }

        private void Start()
        {
            Time.timeScale = 1;
            GameModel gameModel = FindObjectOfType<GameModel>();
            GameStartedEvent onGameStartedEvent = Events.OnGameStartedEvent;
            onGameStartedEvent.gameConfig = gameModel.gameConfig;
            EventsManager.Broadcast(onGameStartedEvent);
        }

        private void OnDisable()
        {
            EventsManager.RemoveListener<PlanetCapturedEvent>(OnPlanetCaptured);
        }

        private void OnPlanetCaptured(PlanetCapturedEvent evt) => CheckGameOver(evt.planet.controlledBy);

        private void CheckGameOver(TeamMember member)
        {
            List<Planet> opponentPlanets = gameModel.planetsModel.GetOpponentControlledPlanets(member);

            if (opponentPlanets.Count == 0)
            {
                GameOverEvent gameOverEvent = Events.GameOverEvent;
                gameOverEvent.isPlayerWon = member == gameModel.teamsModel.player;
                EventsManager.Broadcast(gameOverEvent);
                Time.timeScale = 0;
            }
        }
    }
}

