using UnityEngine;
using UnityEngine.AI;

namespace GalconTechDemo.Gameplay
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Navigation : MonoBehaviour
    {
        private NavMeshAgent navAgent;
        private GameConfig gameConfig;

        private void Awake()
        {
            navAgent = GetComponent<NavMeshAgent>();
            gameConfig = FindObjectOfType<GameModel>().gameConfig;
        }

        private void Update()
        {
            navAgent.speed = gameConfig.shipsFlySpeed;
            navAgent.acceleration = gameConfig.shipsFlyAcceleration;
        }

        public void MoveTo(Vector3 destination)
        {
            navAgent.SetDestination(destination);
        }
    }
}

