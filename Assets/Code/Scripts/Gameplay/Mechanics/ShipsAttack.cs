using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public class ShipsAttack : MonoBehaviour
    {
        public Transform shipsContainer;
        public Ship shipPrefab;

        private GameConfig gameConfig;

        private void Awake()
        {
            gameConfig = FindObjectOfType<GameModel>().gameConfig;
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

            ISpawnShips shipsSpawner = new ShipsSpawner();
            for (int i = 0; i < attackingShipsCount; i++)
            {
                Ship ship = shipsSpawner.SpawnShip(shipPrefab, attackerPlanet.transform.position, shipsContainer);
                ship.AssignTo(attackerPlanet.controlledBy);
                ship.Capture(defenderPlanet);
            }
        }
    }
}

