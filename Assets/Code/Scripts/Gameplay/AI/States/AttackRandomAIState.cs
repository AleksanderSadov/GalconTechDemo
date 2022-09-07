namespace GalconTechDemo.Gameplay
{
    public class AttackRandomAIState : AIState
    {
        public override void Init(GameConfig gameConfig, PlanetsModel planetsModel, TeamMember teamMember)
        {
            base.Init(gameConfig, planetsModel, teamMember);

            Planet botPlanet = planetsModel.GetRandomControlledPlanet(teamMember);
            Planet planetTarget = planetsModel.GetRandomOpponentPlanet(teamMember);

            AttackPlanetEvent attackPlanetEvent = Events.AttackPlanetEvent;
            attackPlanetEvent.attackerPlanet = botPlanet;
            attackPlanetEvent.defenderPlanet = planetTarget;
            EventsManager.Broadcast(attackPlanetEvent);
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

