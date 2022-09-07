using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public class SelectAttackAIState : AIState
    {
        private AIState nextAIState;

        public override void Init(GameConfig gameConfig, PlanetsModel planetsModel, TeamMember teamMember)
        {
            base.Init(gameConfig, planetsModel, teamMember);
            int randomIndex = Random.Range(0, 2);
            switch (randomIndex)
            {
                case 0:
                    nextAIState = new AttackRandomAIState();
                    break;
                default:
                    nextAIState = new AttackRandomAIState();
                    break;
            }
        }

        public override AIState UpdateStateTransitions()
        {
            return nextAIState;
        }

        public override void UpdateState()
        {
            
        }

        public override void Exit()
        {
            
        }
    }
}

