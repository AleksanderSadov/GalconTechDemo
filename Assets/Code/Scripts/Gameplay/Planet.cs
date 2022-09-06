using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public class Planet : MonoBehaviour, IRadius
    {
        public float GetRadius()
        {
            return transform.localScale.x;
        }
    }
}

