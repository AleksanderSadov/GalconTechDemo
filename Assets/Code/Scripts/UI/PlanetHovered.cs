using GalconTechDemo.Gameplay;
using UnityEngine;

namespace GalconTechDemo.UI
{
    public class PlanetHovered : MonoBehaviour
    {
        private void OnEnable()
        {
            EventsManager.AddListener<PlanetEnterHoverEvent>(OnPlanetEnterHover);
            EventsManager.AddListener<PlanetExitHoverEvent>(OnPlanetExitHover);
        }

        private void OnDisable()
        {
            EventsManager.RemoveListener<PlanetEnterHoverEvent>(OnPlanetEnterHover);
            EventsManager.RemoveListener<PlanetExitHoverEvent>(OnPlanetExitHover);
        }

        private void OnPlanetEnterHover(PlanetEnterHoverEvent evt)
        {
            IHoverHighlight highlighter = evt.planet.GetComponentInChildren<IHoverHighlight>();
            if (highlighter != null)
            {
                highlighter.AddHighlight();
            }
        }

        private void OnPlanetExitHover(PlanetExitHoverEvent evt)
        {
            IHoverHighlight highlighter = evt.planet.GetComponentInChildren<IHoverHighlight>();
            if (highlighter != null)
            {
                highlighter.RemoveHighlight();
            }
        }
    }
}

