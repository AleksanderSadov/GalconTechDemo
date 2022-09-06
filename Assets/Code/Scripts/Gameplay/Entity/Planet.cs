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

        private void Awake()
        {
            SetRandomShipsOnStart();
        }

        private void Update()
        {
            GenerateShips();
        }

        public float GetRadius()
        {
            return GetComponent<SphereCollider>().radius * transform.localScale.x;
        }

        public void AssignTo(TeamMember teamMember)
        {
            controlledBy = teamMember;
            ChangeMaterial(teamMember.controlledPlanetMaterial);
        }

        public void ChangeMaterial(Material material)
        {
            GetComponent<MeshRenderer>().material = material;
        }

        private void GenerateShips()
        {
            if (controlledBy != null)
            {
                _currentShipsCount += config.shipsGenerationSpeed * Time.deltaTime;
            }
        }

        private void SetRandomShipsOnStart()
        {
            _currentShipsCount = Random.Range(config.minShipsOnStart, config.maxShipsOnStart + 1);
        }
    }
}

