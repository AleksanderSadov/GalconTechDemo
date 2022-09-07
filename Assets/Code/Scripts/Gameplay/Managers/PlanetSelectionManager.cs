using System.Collections.Generic;
using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public class PlanetSelectionManager : MonoBehaviour
    {
        private List<Planet> selectedPlanets = new List<Planet>();

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
        private void OnPlaneClicked(PlaneClickedEvent evt) => DeselectPlanets();

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

