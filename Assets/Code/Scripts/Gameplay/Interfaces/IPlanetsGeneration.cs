namespace GalconTechDemo.Gameplay
{
    public interface IPlanetsGeneration
    {
        public Planet GenerateNextPlanet(float minPlanetRadius, float maxPlanetRadius);
    }
}

