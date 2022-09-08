namespace GalconTechDemo.Gameplay
{
    public class AttackPlayerAIState : AIState
    {
        public override void Init(GameModel gameModel, TeamMember botMember)
        {
            base.Init(gameModel, botMember);
            stateLabel = BotAIStatesLabel.AttackPlayer;

            Planet botPlanet = gameModel.planetsModel.GetRandomControlledPlanet(botMember);
            Planet planetTarget = gameModel.planetsModel.GetRandomOpponentControlledPlanet(botMember);

            if (planetTarget == null)
            {
                planetTarget = gameModel.planetsModel.GetRandomOpponentOrFreePlanet(botMember);
            }

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

