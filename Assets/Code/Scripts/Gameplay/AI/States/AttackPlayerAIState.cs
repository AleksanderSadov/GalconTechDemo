namespace GalconTechDemo.Gameplay
{
    public class AttackPlayerAIState : AIState
    {
        public override void Init(GameConfig gameConfig, PlanetsModel planetsModel, TeamMember botMember)
        {
            base.Init(gameConfig, planetsModel, botMember);
            stateLabel = BotAIStatesLabel.AttackPlayer;

            Planet botPlanet = planetsModel.GetRandomControlledPlanet(botMember);
            Planet planetTarget = planetsModel.GetRandomOpponentControlledPlanet(botMember);

            if (planetTarget == null)
            {
                planetTarget = planetsModel.GetRandomOpponentOrFreePlanet(botMember);
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

