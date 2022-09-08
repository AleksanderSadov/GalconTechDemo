using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public class SelectAttackAIState : AIState
    {
        private AIState nextAIState;

        public override void Init(GameModel gameModel, TeamMember botMember)
        {
            base.Init(gameModel, botMember);
            stateLabel = BotAIStatesLabel.SelectAttack;

            int randomIndex = Random.Range(0, 3);
            switch (randomIndex)
            {
                case 0:
                    nextAIState = new AttackRandomAIState();
                    break;
                case 1:
                    nextAIState = new AttackPlayerAIState();
                    break;
                case 2:
                    nextAIState = new AttackCaptureAIState();
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

