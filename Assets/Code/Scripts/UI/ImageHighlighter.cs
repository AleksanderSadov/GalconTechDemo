using GalconTechDemo.Gameplay;
using UnityEngine;

namespace GalconTechDemo.UI
{
    public class ImageHighlighter : MonoBehaviour, IHighlight
    {
        public GameObject hightlightImage;

        public void AddHighlight()
        {
            hightlightImage?.SetActive(true);
        }

        public void RemoveHighlight()
        {
            hightlightImage?.SetActive(false);
        }
    }
}

