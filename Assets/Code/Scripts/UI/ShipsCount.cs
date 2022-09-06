using GalconTechDemo.Gameplay;
using TMPro;
using UnityEngine;

namespace GalconTechDemo.UI
{
    public class ShipsCount : MonoBehaviour
    {
        public Planet planet;
        public TextMeshProUGUI shipsCountText;

        private void Update()
        {
            shipsCountText.text = planet.currentShipsCount.ToString();
        }
    }
}

