using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    [RequireComponent(typeof(Navigation))]
    [RequireComponent(typeof(Ownership))]
    public class Ship : MonoBehaviour
    {
        private Navigation navigation;
        private Ownership ownership;

        public TeamMember controlledBy => ownership.controlledBy;

        private void Awake()
        {
            navigation = GetComponent<Navigation>();
            ownership = GetComponent<Ownership>();
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
    }
}

