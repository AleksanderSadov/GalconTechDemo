using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public abstract class PlanetsGenerationMethod : MonoBehaviour, IPlanetsGeneration
    {
        protected readonly Vector3 PLANE_DEFAULT_SIZE = new Vector3(10f, 0f, 10f);

        [HideInInspector]
        public bool canTryMore = true;

        [SerializeField]
        protected Transform playablePlane;
        [SerializeField]
        protected Planet planetPrefab;

        protected float minPlanetScale;
        protected float maxPlanetScale;
        protected float minPlanetRadius;
        protected float maxPlanetRadius;

        public abstract Planet GenerateNextPlanet();

        public virtual void Init(float minPlanetScale, float maxPlanetScale)
        {
            this.minPlanetScale = minPlanetScale;
            this.maxPlanetScale = maxPlanetScale;
            minPlanetRadius = planetPrefab.GetRadius() * minPlanetScale;
            maxPlanetRadius = planetPrefab.GetRadius() * maxPlanetScale;
        }

        public virtual void Free()
        {

        }
    }
}

