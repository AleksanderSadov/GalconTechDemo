namespace GalconTechDemo.Gameplay
{
    [System.Serializable]
    public abstract class AIState
    {
        private GameConfig gameConfig;
        private PlanetsModel planetsModel;
        private TeamMember teamMember;

        public virtual void Init(GameConfig gameConfig, PlanetsModel planetsModel, TeamMember teamMember) 
        {
            this.gameConfig = gameConfig;
            this.planetsModel = planetsModel;
            this.teamMember = teamMember;
        }

        public abstract AIState UpdateStateTransitions();
        public virtual void UpdateState() { }
        public virtual void Exit() { }
    }
}

