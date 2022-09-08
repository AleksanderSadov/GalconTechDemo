using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public class CapturePlanet : MonoBehaviour
    {
        public Planet targetPlanet;
        public TeamMember attacker;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Planet"))
            {
                return;
            }

            Planet collidingPlanet = other.GetComponent<Planet>();
            if (collidingPlanet == null || targetPlanet != collidingPlanet)
            {
                return;
            }

            Attack(collidingPlanet);
            Destroy(gameObject);
        }

        private void Attack(Planet defenderPlanet)
        {
            if (defenderPlanet.controlledBy != attacker)
            {
                defenderPlanet.currentShipsCount -= 1;

                if (defenderPlanet.currentShipsCount <= 0)
                {
                    defenderPlanet.AssignTo(attacker);

                    PlanetCapturedEvent planetCapturedEvent = Events.PlanetCapturedEvent;
                    planetCapturedEvent.planet = defenderPlanet;
                    EventsManager.Broadcast(planetCapturedEvent);
                }
            }
            else
            {
                defenderPlanet.currentShipsCount += 1;
            }
        }
    }
}

