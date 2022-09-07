using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public class Plane : MonoBehaviour
    {
        private void OnMouseDown()
        {
            PlaneClickedEvent planeClicked = Events.PlaneClicked;
            EventsManager.Broadcast(planeClicked);
        }
    }
}

