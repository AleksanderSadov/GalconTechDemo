using System.Collections.Generic;
using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public class PlanetSelectionManager : MonoBehaviour
    {
        private List<Planet> selectedPlanets = new List<Planet>();

        private void OnEnable()
        {
            EventsManager.AddListener<PlanetSelectedEvent>(OnPlanetSelected);
            EventsManager.AddListener<PlaneClicked>(OnPlaneClicked);
        }

        private void OnDisable()
        {
            EventsManager.RemoveListener<PlanetSelectedEvent>(OnPlanetSelected);
            EventsManager.RemoveListener<PlaneClicked>(OnPlaneClicked);
        }

        private void OnPlanetSelected(PlanetSelectedEvent evt) => SelectPlanet(evt.planet);
        private void OnPlaneClicked(PlaneClicked evt) => DeselectPlanets();

        private void SelectPlanet(Planet planet)
        {
            selectedPlanets.Add(planet);
            AddHighlight(planet);
        }

        private void DeselectPlanets()
        {
            foreach (Planet planet in selectedPlanets)
            {
                RemoveHighlight(planet);
            }

            selectedPlanets.Clear();
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

