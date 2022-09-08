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
            AttackHelper.AttackPlanet(lastSelectedPlanet, defenderPlanet);
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

