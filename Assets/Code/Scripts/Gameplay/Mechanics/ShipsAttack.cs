using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public class ShipsAttack : MonoBehaviour
    {
        private GameConfig gameConfig;

        private void Awake()
        {
            gameConfig = FindObjectOfType<GameManager>().gameConfig;
        }

        public void OnEnable()
        {
            EventsManager.AddListener<AttackPlanetEvent>(OnAttackPlanet);
        }

        public void OnDisable()
        {
            EventsManager.RemoveListener<AttackPlanetEvent>(OnAttackPlanet);
        }

        private void OnAttackPlanet(AttackPlanetEvent evt) => AttackPlanet(evt.attackerPlanet, evt.defenderPlanet);

        private void AttackPlanet(Planet attackerPlanet, Planet defenderPlanet)
        {
            int attackingShipsCount = (int) Mathf.Floor(attackerPlanet.currentShipsCount * gameConfig.shipsAttackPercentage);
            attackerPlanet.currentShipsCount -= attackingShipsCount;
            DefendPlanet(defenderPlanet, attackingShipsCount, attackerPlanet.controlledBy);
        }

        private void DefendPlanet(Planet defenderPlanet, int attackingShipsCount, TeamMember attacker)
        {
            defenderPlanet.currentShipsCount -= attackingShipsCount;

            if (defenderPlanet.currentShipsCount <= 0)
            {
                defenderPlanet.AssignTo(attacker);
                defenderPlanet.currentShipsCount *= -1;
            }
        }
    }
}

