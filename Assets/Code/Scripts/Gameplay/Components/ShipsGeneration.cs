using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public class ShipsGeneration : MonoBehaviour
    {
        public int currentShipsCount
        {
            get
            {
                return (int)Mathf.Floor(_currentShipsCount);
            }

            set
            {
                _currentShipsCount = value;
            }
        }
        private float _currentShipsCount = 0f;

        public void GenerateShips(float speed)
        {
             _currentShipsCount += speed * Time.deltaTime;
        }
    }
}

