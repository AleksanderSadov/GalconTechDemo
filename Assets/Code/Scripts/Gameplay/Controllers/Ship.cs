using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    [RequireComponent(typeof(Navigation))]
    [RequireComponent(typeof(Ownership))]
    [RequireComponent(typeof(CapturePlanet))]
    public class Ship : MonoBehaviour
    {
        public TeamMember controlledBy => ownership.controlledBy;

        private Navigation navigation;
        private Ownership ownership;
        private CapturePlanet capturePlanet;

        private void Awake()
        {
            navigation = GetComponent<Navigation>();
            ownership = GetComponent<Ownership>();
            capturePlanet = GetComponent<CapturePlanet>();
        }

        public void AssignTo(TeamMember teamMember)
        {
            ownership.AssignTo(teamMember);
            ChangeMaterial(teamMember.controlledShipMaterial);
        }

        public void ChangeMaterial(Material material)
        {
            GetComponent<MeshRenderer>().material = material;
        }

        public void MoveTo(Vector3 destination) => navigation.MoveTo(destination);

        public void Capture(Planet targetPlanet)
        {
            capturePlanet.targetPlanet = targetPlanet;
            capturePlanet.attacker = ownership.controlledBy;
            MoveTo(targetPlanet.GetClosestPositionOnSurface(transform.position));
        }
    }
}

