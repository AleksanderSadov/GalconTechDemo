using GalconTechDemo.Gameplay;
using UnityEngine;

namespace GalconTechDemo.UI
{
    public class ImageHighlighter : MonoBehaviour, IHighlight
    {
        public GameObject hightlightImage;

        public void Highlight()
        {
            hightlightImage.SetActive(true);
        }
    }
}

