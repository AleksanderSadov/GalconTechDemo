using UnityEngine;
using UnityEngine.AI;

namespace GalconTechDemo.Gameplay
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Navigation : MonoBehaviour
    {
        private NavMeshAgent navAgent;

        private void Awake()
        {
            navAgent = GetComponent<NavMeshAgent>();
        }

        public void MoveTo(Vector3 destination)
        {
            navAgent.SetDestination(destination);
        }
    }
}

