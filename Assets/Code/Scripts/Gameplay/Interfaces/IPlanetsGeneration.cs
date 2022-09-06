namespace GalconTechDemo.Gameplay
{
    public interface IPlanetsGeneration
    {
        public void Init(float minPlanetScale, float maxPlanetScale);
        public Planet GenerateNextPlanet();
        public void Free();
    }
}

