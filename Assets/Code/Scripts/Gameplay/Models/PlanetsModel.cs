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
            List<Planet> notControlledPlanets = GetNotControlledPlanets();

            if (notControlledPlanets.Count == 0)
            {
                return null;
            }

            int randomIndex = Random.Range(0, notControlledPlanets.Count);
            return notControlledPlanets[randomIndex];
        }

        public List<Planet> GetControlledPlanets(TeamMember teamMember)
        {
            return planets.FindAll(p => p.controlledBy == teamMember);
        }

        public Planet GetRandomControlledPlanet(TeamMember teamMember)
        {
            List<Planet> controlledPlanets = GetControlledPlanets(teamMember);

            if (controlledPlanets.Count == 0)
            {
                return null;
            }

            int randomIndex = Random.Range(0, controlledPlanets.Count);
            return controlledPlanets[randomIndex];
        }

        public List<Planet> GetOpponentControlledPlanets(TeamMember teamMember)
        {
            return planets.FindAll(p => p.controlledBy != null && p.controlledBy != teamMember);
        }

        public Planet GetRandomOpponentControlledPlanet(TeamMember teamMember)
        {
            List<Planet> controlledPlanets = GetOpponentControlledPlanets(teamMember);

            if (controlledPlanets.Count == 0)
            {
                return null;
            }

            int randomIndex = Random.Range(0, controlledPlanets.Count);
            return controlledPlanets[randomIndex];
        }

        public List<Planet> GetOpponentOrFreePlanets(TeamMember teamMember)
        {
            return planets.FindAll(p => p.controlledBy != teamMember);
        }

        public Planet GetRandomOpponentOrFreePlanet(TeamMember teamMember)
        {
            List<Planet> opponentPlanets = GetOpponentOrFreePlanets(teamMember);

            if (planets.Count == 0)
            {
                return null;
            }

            int randomIndex = Random.Range(0, opponentPlanets.Count);
            return opponentPlanets[randomIndex];
        }
    }
}
