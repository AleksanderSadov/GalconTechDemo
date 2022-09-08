using GalconTechDemo.Gameplay;
using UnityEngine;

namespace GalconTechDemo.UI
{
    public class OverlapHighlighter : MonoBehaviour, IHoverHighlight
    {
        public GameObject overlapObject;

        public void AddHighlight()
        {
            overlapObject.SetActive(true);
        }

        public void RemoveHighlight()
        {
            overlapObject.SetActive(false);
        }
    }
}

