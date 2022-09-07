using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    [RequireComponent(typeof(Ownership))]
    [RequireComponent(typeof(ShipsGeneration))]
    public class Planet : MonoBehaviour, IRadius
    {
        public PlanetConfig config;

        public TeamMember controlledBy => ownership.controlledBy;
        public int currentShipsCount
        {
            get => shipsGeneration.currentShipsCount;
            set => shipsGeneration.currentShipsCount = value; 
        }

        private Ownership ownership;
        private ShipsGeneration shipsGeneration;

        private void Awake()
        {
            ownership = GetComponent<Ownership>();
            shipsGeneration = GetComponent<ShipsGeneration>();

            SetRandomShipsOnStart();
        }

        private void Update()
        {
            if (ownership.controlledBy != null)
            {
                shipsGeneration.GenerateShips(config.shipsGenerationSpeed);
            }
        }

        public float GetRadius()
        {
            return GetComponent<SphereCollider>().radius * transform.localScale.x;
        }

        public void AssignTo(TeamMember teamMember)
        {
            ownership.AssignTo(teamMember);
            ChangeMaterial(teamMember.controlledPlanetMaterial);
        }

        public void ChangeMaterial(Material material)
        {
            GetComponent<MeshRenderer>().material = material;
        }

        private void SetRandomShipsOnStart()
        {
            shipsGeneration.currentShipsCount = Random.Range(
                config.minShipsOnStart,
                config.maxShipsOnStart + 1
            );
        }

        private void OnMouseDown()
        {
            PlanetClickedEvent planetSelectedEvent = Events.PlanetSelectedEvent;
            planetSelectedEvent.planet = this;
            EventsManager.Broadcast(planetSelectedEvent);
        }
    }
}

