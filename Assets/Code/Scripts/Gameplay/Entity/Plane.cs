using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public class Plane : MonoBehaviour
    {
        private void OnMouseDown()
        {
            PlaneClicked planeClicked = Events.PlaneClicked;
            EventsManager.Broadcast(planeClicked);
        }
    }
}

