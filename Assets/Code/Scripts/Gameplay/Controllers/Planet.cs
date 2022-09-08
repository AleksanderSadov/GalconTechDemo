using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    [RequireComponent(typeof(Ownership))]
    [RequireComponent(typeof(ShipsGeneration))]
    public class Planet : MonoBehaviour, IRadius
    {
        public GameConfig config;

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
            config = FindObjectOfType<GameModel>().gameConfig;

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

        public Vector3 GetClosestPositionOnSurface(Vector3 targetPosition)
        {
            Vector3 planetCenter = transform.position;
            return planetCenter - (planetCenter - targetPosition).normalized * GetRadius();
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
                config.shipsMinOnPlanetStart,
                config.shipsMaxOnPlanetStart + 1
            );
        }

        private void OnMouseDown()
        {
            PlanetClickedEvent planetClickedEvent = Events.PlanetClickedEvent;
            planetClickedEvent.planet = this;
            EventsManager.Broadcast(planetClickedEvent);
        }

        private void OnMouseEnter()
        {
            PlanetEnterHoverEvent planetEnterHoverEvent = Events.PlanetEnterHoverEvent;
            planetEnterHoverEvent.planet = this;
            EventsManager.Broadcast(planetEnterHoverEvent);
        }

        private void OnMouseExit()
        {
            PlanetExitHoverEvent planetExitHoverEvent = Events.PlanetExitHoverEvent;
            planetExitHoverEvent.planet = this;
            EventsManager.Broadcast(planetExitHoverEvent);
        }
    }
}

