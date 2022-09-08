using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public class AttackCooldownAIState : AIState
    {
        private float cooldownSeconds = 5;
        private float timeStarted;
        private bool isCooldownExpired = false;

        public override void Init(GameModel gameModel, TeamMember botMember)
        {
            base.Init(gameModel, botMember);
            stateLabel = BotAIStatesLabel.AttackCooldown;
            cooldownSeconds = gameModel.gameConfig.enemyDecisionsCooldown;
            timeStarted = Time.time;
        }

        public override AIState UpdateStateTransitions()
        {
            if (isCooldownExpired)
            {
                return new SelectAttackAIState();
            }

            return null;
        }

        public override void UpdateState()
        {
            if (Time.time - timeStarted > cooldownSeconds)
            {
                isCooldownExpired = true;
            }
        }

        public override void Exit()
        {
            
        }
    }
}

