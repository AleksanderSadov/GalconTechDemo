using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public class PlanetSelectionController : MonoBehaviour
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
            AddHighlight(planet);
        }

        private void DeselectPlanet()
        {
            if (lastSelectedPlanet != null)
            {
                RemoveHighlight(lastSelectedPlanet);
                lastSelectedPlanet = null;
            }
        }

        private void AttackPlanet(Planet defenderPlanet)
        {
            AttackPlanetEvent attackPlanetEvent = Events.AttackPlanetEvent;
            attackPlanetEvent.attackerPlanet = lastSelectedPlanet;
            attackPlanetEvent.defenderPlanet = defenderPlanet;
            EventsManager.Broadcast(attackPlanetEvent);

            DeselectPlanet();
        }

        private void AddHighlight(Planet planet)
        {
            IHighlight highlighter = planet.GetComponentInChildren<IHighlight>();
            if (highlighter != null)
            {
                highlighter.AddHighlight();
            }
        }

        private void RemoveHighlight(Planet planet)
        {
            IHighlight highlighter = planet.GetComponentInChildren<IHighlight>();
            if (highlighter != null)
            {
                highlighter.RemoveHighlight();
            }
        }
    }
}

