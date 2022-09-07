using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public class PlaneController : MonoBehaviour
    {
        private Plane plane;

        private void Awake()
        {
            plane = GetComponent<Plane>();
        }

        private void OnMouseDown()
        {
            PlaneClickedEvent planeClicked = Events.PlaneClicked;
            EventsManager.Broadcast(planeClicked);
        }
    }
}

