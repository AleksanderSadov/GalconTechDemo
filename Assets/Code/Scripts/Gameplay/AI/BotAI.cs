using UnityEngine;

namespace GalconTechDemo.Gameplay
{
    public enum BotAIStatesLabel
    {
        AttackCooldown,
        AttackRandom,
        SelectAttack,
        AttackPlayer,
        AttackCapture,
    }

    [RequireComponent(typeof(TeamMember))]
    public class BotAI : MonoBehaviour
    {
        public AIState currentAIState;
        public BotAIStatesLabel currentAIStateLabel;
        public BotAIStatesLabel previousAIStateLabel;

        private GameConfig gameConfig;
        private PlanetsModel planetsModel;
        private TeamMember teamMember;

        private void Awake()
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            gameConfig = gameManager.gameConfig;
            planetsModel = gameManager.planetsModel;
            teamMember = GetComponent<TeamMember>();
        }

        private void Start()
        {
            currentAIState = new AttackCooldownAIState();
            currentAIState.Init(gameConfig, planetsModel, teamMember);
            currentAIStateLabel = currentAIState.stateLabel;
        }

        private void Update()
        {
            AIState nextAIState = currentAIState.UpdateStateTransitions();
            if (nextAIState != null && nextAIState != currentAIState)
            {
                previousAIStateLabel = currentAIStateLabel;

                currentAIState.Exit();
                currentAIState = nextAIState;
                currentAIState.Init(gameConfig, planetsModel, teamMember);

                currentAIStateLabel = currentAIState.stateLabel;
            }
            currentAIState.UpdateState();
        }
    }
}

