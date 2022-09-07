using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public class PlanetSelectionManager : MonoBehaviour
    {
        private void OnEnable()
        {
            EventsManager.AddListener<PlanetSelectedEvent>(OnPlanetSelected);
        }

        private void OnDisable()
        {
            EventsManager.RemoveListener<PlanetSelectedEvent>(OnPlanetSelected);
        }

        private void OnPlanetSelected(PlanetSelectedEvent evt) => SelectPlanet(evt.planet);

        private void SelectPlanet(Planet planet)
        {
            IHighlight highlighter = planet.GetComponentInChildren<IHighlight>();
            if (highlighter != null)
            {
                highlighter.Highlight();
            }    
        }
    }
}

