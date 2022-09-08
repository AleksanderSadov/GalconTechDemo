using GalconTechDemo.Gameplay;
using UnityEngine;

namespace GalconTechDemo.UI
{
    public class GameOverScreen : MonoBehaviour
    {
        public GameObject gameOverCanvas;
        public GameObject youWinText;
        public GameObject youLoseText;

        private void OnEnable()
        {
            EventsManager.AddListener<GameStartedEvent>(OnGameStarted);
            EventsManager.AddListener<GameOverEvent>(OnGameOver);
        }

        private void OnDisable()
        {
            EventsManager.RemoveListener<GameStartedEvent>(OnGameStarted);
            EventsManager.RemoveListener<GameOverEvent>(OnGameOver);
        }

        private void OnGameStarted(GameStartedEvent evt)
        {
            gameOverCanvas.SetActive(false);
        }

        private void OnGameOver(GameOverEvent evt)
        {
            gameOverCanvas.SetActive(true);

            if (evt.isPlayerWon)
            {
                youWinText.SetActive(true);
                youLoseText.SetActive(false);
            }
            else
            {
                youWinText.SetActive(false);
                youLoseText.SetActive(true);
            }
        }
    }
}

