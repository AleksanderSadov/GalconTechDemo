using System.Collections.Generic;
using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    [System.Serializable]
    public class PlanetsModel
    {
        public List<Planet> planets = new List<Planet>();

        public List<Planet> GetNotControlledPlanets()
        {
            return planets.FindAll(p => p.controlledBy == null);
        }

        public List<Planet> GetControlledPlanets(TeamMember teamMember)
        {
            return planets.FindAll(p => p.controlledBy == teamMember);
        }

        public List<Planet> GetOpponentControlledPlanets(TeamMember teamMember)
        {
            return planets.FindAll(p => p.controlledBy != null && p.controlledBy != teamMember);
        }

        public List<Planet> GetOpponentOrFreePlanets(TeamMember teamMember)
        {
            return planets.FindAll(p => p.controlledBy != teamMember);
        }

        public Planet GetRandomPlanet()
        {
            if (planets.Count == 0)
            {
                return null;
            }

            int randomIndex = Random.Range(0, planets.Count);
            return planets[randomIndex];
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

        public Planet GetRandomOpponentOrFreePlanet(TeamMember teamMember)
        {
            List<Planet> opponentPlanets = GetOpponentOrFreePlanets(teamMember);

            if (opponentPlanets.Count == 0)
            {
                return null;
            }

            int randomIndex = Random.Range(0, opponentPlanets.Count);
            return opponentPlanets[randomIndex];
        }

        public Planet GetMemberStrongestPlanet(TeamMember teamMember)
        {
            List<Planet> controlledPlanets = GetControlledPlanets(teamMember);

            Planet strongestPlanet = null;
            foreach (Planet planet in controlledPlanets)
            {
                if (strongestPlanet == null || planet.currentShipsCount > strongestPlanet.currentShipsCount)
                {
                    strongestPlanet = planet;
                }
            }

            return strongestPlanet;
        }

        public Planet GetOpponentOrFreeWeakestPlanet(TeamMember teamMember)
        {
            List<Planet> controlledPlanets = GetOpponentOrFreePlanets(teamMember);

            Planet weakestPlanet = null;
            foreach (Planet planet in controlledPlanets)
            {
                if (weakestPlanet == null || planet.currentShipsCount < weakestPlanet.currentShipsCount)
                {
                    weakestPlanet = planet;
                }
            }

            return weakestPlanet;
        }
    }
}
