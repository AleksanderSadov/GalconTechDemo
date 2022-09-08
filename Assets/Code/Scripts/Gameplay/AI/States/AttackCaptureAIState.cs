namespace GalconTechDemo.Gameplay
{
    public class AttackCaptureAIState : AIState
    {
        public override void Init(GameModel gameModel, TeamMember botMember)
        {
            base.Init(gameModel, botMember);
            stateLabel = BotAIStatesLabel.AttackCapture;

            Planet botPlanet = gameModel.planetsModel.GetMemberStrongestPlanet(botMember);
            Planet planetTarget = gameModel.planetsModel.GetOpponentOrFreeWeakestPlanet(botMember);

            AttackHelper.AttackPlanet(botPlanet, planetTarget);
        }

        public override AIState UpdateStateTransitions()
        {
            return new AttackCooldownAIState();
        }

        public override void UpdateState()
        {
            
        }

        public override void Exit()
        {
            
        }
    }
}

