using GalconTechDemo.Gameplay;
using UnityEngine;

namespace GalconTechDemo.UI
{
    public class PlanetSelected : MonoBehaviour
    {
        private void OnEnable()
        {
            EventsManager.AddListener<PlanetSelectedEvent>(OnPlanetSelected);
            EventsManager.AddListener<PlanetDeselectedEvent>(OnPlanetDeselected);
        }

        private void OnDisable()
        {
            EventsManager.RemoveListener<PlanetSelectedEvent>(OnPlanetSelected);
            EventsManager.RemoveListener<PlanetDeselectedEvent>(OnPlanetDeselected);
        }

        private void OnPlanetSelected(PlanetSelectedEvent evt)
        {
            ISelectHighlight highlighter = evt.planet.GetComponentInChildren<ISelectHighlight>();
            if (highlighter != null)
            {
                highlighter.AddHighlight();
            }
        }

        private void OnPlanetDeselected(PlanetDeselectedEvent evt)
        {
            ISelectHighlight highlighter = evt.planet.GetComponentInChildren<ISelectHighlight>();
            if (highlighter != null)
            {
                highlighter.RemoveHighlight();
            }
        }
    }
}

