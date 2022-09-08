namespace GalconTechDemo.Gameplay
{
    public class AttackCaptureAIState : AIState
    {
        public override void Init(GameConfig gameConfig, PlanetsModel planetsModel, TeamMember botMember)
        {
            base.Init(gameConfig, planetsModel, botMember);
            stateLabel = BotAIStatesLabel.AttackCapture;

            Planet botPlanet = planetsModel.GetMemberStrongestPlanet(botMember);
            Planet planetTarget = planetsModel.GetOpponentOrFreeWeakestPlanet(botMember);

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

