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

        private GameModel gameModel;
        private TeamMember teamMember;

        private void Awake()
        {
            gameModel = FindObjectOfType<GameModel>();
            teamMember = GetComponent<TeamMember>();
        }

        private void Start()
        {
            currentAIState = new AttackCooldownAIState();
            currentAIState.Init(gameModel, teamMember);
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
                currentAIState.Init(gameModel, teamMember);

                currentAIStateLabel = currentAIState.stateLabel;
            }
            currentAIState.UpdateState();
        }
    }
}

