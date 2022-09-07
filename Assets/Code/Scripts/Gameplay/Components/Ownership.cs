using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public class Ownership : MonoBehaviour
    {
        public TeamMember controlledBy;

        public void AssignTo(TeamMember teamMember)
        {
            controlledBy = teamMember;
        }
    }
}

