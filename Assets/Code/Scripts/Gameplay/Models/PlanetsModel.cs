using System.Collections.Generic;
using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public class PlanetsModel : MonoBehaviour
    {
        public List<Planet> planets = new List<Planet>();

        public Planet GetRandomPlanet()
        {
            if (planets.Count == 0)
            {
                return null;
            }

            int randomIndex = Random.Range(0, planets.Count);
            return planets[randomIndex];
        }

        public List<Planet> GetNotControlledPlanets()
        {
            return planets.FindAll(p => p.controlledBy == null);
        }

        public Planet GetRandomNotControlledPlanet()
        {
            if (planets.Count == 0)
            {
                return null;
            }

            List<Planet> notControlledPlanets = GetNotControlledPlanets();
            int randomIndex = Random.Range(0, notControlledPlanets.Count);
            return notControlledPlanets[randomIndex];
        }
    }
}
