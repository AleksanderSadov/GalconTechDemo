using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public class Navigation : MonoBehaviour
    {
        private Vector3 destination;
        private bool hasReachedDestination = true;
        private float speed = 10f;

        private void Update()
        {
            if (!hasReachedDestination)
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, destination, step);
            }

            if (Vector3.Distance(transform.position, destination) <= 0.1f)
            {
                hasReachedDestination = true;
            }
        }

        public void MoveTo(Vector3 destination)
        {
            this.destination = destination;
            hasReachedDestination = false;
        }
    }
}

