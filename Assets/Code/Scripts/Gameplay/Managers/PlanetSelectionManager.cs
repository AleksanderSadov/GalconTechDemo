using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public class PlanetSelectionManager : MonoBehaviour
    {
        private Planet selectedPlanet;

        private void OnEnable()
        {
            EventsManager.AddListener<PlanetClickedEvent>(OnPlanetSelected);
            EventsManager.AddListener<PlaneClickedEvent>(OnPlaneClicked);
        }

        private void OnDisable()
        {
            EventsManager.RemoveListener<PlanetClickedEvent>(OnPlanetSelected);
            EventsManager.RemoveListener<PlaneClickedEvent>(OnPlaneClicked);
        }

        private void OnPlanetSelected(PlanetClickedEvent evt) => SelectPlanet(evt.planet);
        private void OnPlaneClicked(PlaneClickedEvent evt) => DeselectPlanet();

        private void SelectPlanet(Planet planet)
        {
            if (planet.controlledBy?.teamAffiliation != TeamAffiliation.Player)
            {
                return;
            }

            selectedPlanet = planet;
            AddHighlight(planet);
        }

        private void DeselectPlanet()
        {
            RemoveHighlight(selectedPlanet);
            selectedPlanet = null;
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

