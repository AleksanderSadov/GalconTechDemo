using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public class PlanetController : MonoBehaviour
    {
        private Planet planet;

        private void Awake()
        {
            planet = GetComponent<Planet>();
            planet.SetRandomShipsOnStart();
        }

        private void Update()
        {
            planet.GenerateShips();
        }

        private void OnMouseDown()
        {
            PlanetClickedEvent planetSelectedEvent = Events.PlanetSelectedEvent;
            planetSelectedEvent.planet = planet;
            EventsManager.Broadcast(planetSelectedEvent);
        }
    }
}

