namespace GalconTechDemo.Gameplay
{
    [System.Serializable]
    public abstract class AIState
    {
        public BotAIStatesLabel stateLabel;

        private GameModel gameModel;
        private TeamMember teamMember;

        public virtual void Init(GameModel gameModel, TeamMember teamMember) 
        {
            this.gameModel = gameModel;
            this.teamMember = teamMember;
        }

        public abstract AIState UpdateStateTransitions();
        public virtual void UpdateState() { }
        public virtual void Exit() { }
    }
}

