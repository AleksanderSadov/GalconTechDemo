using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public interface IPlanetsGeneration
    {
        public Planet GenerateNextPlanet(Planet previousPlanet, float minPlanetRadius, float maxPlanetRadius);
    }
}

