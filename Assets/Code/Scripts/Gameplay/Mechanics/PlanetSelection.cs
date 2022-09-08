using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public class PlanetSelection : MonoBehaviour
    {
        private Planet lastSelectedPlanet;

        private void OnEnable()
        {
            EventsManager.AddListener<PlanetClickedEvent>(OnPlanetClicked);
            EventsManager.AddListener<PlaneClickedEvent>(OnPlaneClicked);
        }

        private void OnDisable()
        {
            EventsManager.RemoveListener<PlanetClickedEvent>(OnPlanetClicked);
            EventsManager.RemoveListener<PlaneClickedEvent>(OnPlaneClicked);
        }

        private void OnPlanetClicked(PlanetClickedEvent evt)
        {
            if (evt.planet.controlledBy?.teamAffiliation == TeamAffiliation.Player)
            {
                SelectPlanet(evt.planet);
            }

            if (lastSelectedPlanet != null && lastSelectedPlanet != evt.planet)
            {
                AttackPlanet(evt.planet);
                DeselectPlanet();
            }
        }
        private void OnPlaneClicked(PlaneClickedEvent evt) => DeselectPlanet();

        private void SelectPlanet(Planet planet)
        {
            if (lastSelectedPlanet != null)
            {
                DeselectPlanet();
            }

            lastSelectedPlanet = planet;

            PlanetSelectedEvent planetSelectedEvent = Events.PlanetSelectedEvent;
            planetSelectedEvent.planet = lastSelectedPlanet;
            EventsManager.Broadcast(planetSelectedEvent);
        }

        private void DeselectPlanet()
        {
            if (lastSelectedPlanet != null)
            {
                PlanetDeselectedEvent planetDeselectedEvent = Events.PlanetDeselectedEvent;
                planetDeselectedEvent.planet = lastSelectedPlanet;
                EventsManager.Broadcast(planetDeselectedEvent);

                lastSelectedPlanet = null;
            }
        }

        private void AttackPlanet(Planet defenderPlanet)
        {
            AttackHelper.AttackPlanet(lastSelectedPlanet, defenderPlanet);
        }
    }
}

