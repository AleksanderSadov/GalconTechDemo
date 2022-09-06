using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public class Planet : MonoBehaviour, IRadius
    {
        public PlanetConfig config;
        public TeamMember controlledBy;

        public int currentShipsCount
        {
            get 
            {
                return (int) Mathf.Floor(_currentShipsCount);
            }
            
            set
            {
                _currentShipsCount = value;
            }
        }
        private float _currentShipsCount = 0f;

        private void Update()
        {
            GenerateShips();
        }

        public float GetRadius()
        {
            return GetComponent<SphereCollider>().radius * transform.localScale.x;
        }

        private void GenerateShips()
        {
            if (controlledBy != null)
            {
                _currentShipsCount += config.shipsGenerationSpeed * Time.deltaTime;
            }
        }
    }
}

