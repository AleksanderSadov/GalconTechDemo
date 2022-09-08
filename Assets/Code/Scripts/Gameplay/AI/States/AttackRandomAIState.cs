namespace GalconTechDemo.Gameplay
{
    public class AttackRandomAIState : AIState
    {
        public override void Init(GameModel gameModel, TeamMember botMember)
        {
            base.Init(gameModel, botMember);
            stateLabel = BotAIStatesLabel.AttackRandom;

            Planet botPlanet = gameModel.planetsModel.GetRandomControlledPlanet(botMember);
            Planet planetTarget = gameModel.planetsModel.GetRandomOpponentOrFreePlanet(botMember);

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

