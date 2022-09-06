using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public abstract class PlanetsFindSpawnPosition : MonoBehaviour, IPlanetsFindSpawnPosition
    {
        protected readonly Vector3 PLANE_DEFAULT_SIZE = new Vector3(10f, 0f, 10f);

        [HideInInspector]
        public bool canTryMore = true;

        protected Transform playablePlane;
        protected float minPlanetScale;
        protected float maxPlanetScale;
        protected float minPlanetRadius;
        protected float maxPlanetRadius;
        protected LayerMask planetLayerMask;

        public abstract bool GetNextPlanetSpawnPosition(out Vector3 spawnPosition);

        public virtual void Init(
            float planetBaseRadius,
            float minPlanetScale,
            float maxPlanetScale,
            LayerMask planetLayerMask,
            Transform playablePlane
        )
        {
            this.minPlanetScale = minPlanetScale;
            this.maxPlanetScale = maxPlanetScale;
            minPlanetRadius = planetBaseRadius * minPlanetScale;
            maxPlanetRadius = planetBaseRadius * maxPlanetScale;
            this.planetLayerMask = planetLayerMask;
            this.playablePlane = playablePlane;
        }

        public virtual void Free()
        {

        }
    }
}

