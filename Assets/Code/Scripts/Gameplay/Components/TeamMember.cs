using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public enum TeamAffiliation
    {
        Player,
        Enemy,
    }

    public class TeamMember : MonoBehaviour
    {
        public TeamAffiliation teamAffiliation;
        public int shipsOnStart;
        public Material controlledPlanetMaterial;
        public Material controlledShipMaterial;
    }
}
