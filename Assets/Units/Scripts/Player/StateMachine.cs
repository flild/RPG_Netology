using UnityEngine;

namespace RPG.Units.Player
{
    [RequireComponent(typeof(PlayerState))]
    public class AnimStateMachine : MonoBehaviour
    {
        private PlayerState _states;
        private PlayerViewComponent _view;

        private void Start()
        {
            _states = GetComponent<PlayerState>();
            _view = GetComponent<PlayerViewComponent>();
        }
        private void Update()
        {
            _view.CrouchAnim(_states.isCrouching);
            _view.SprintAnim(_states.isSprinting);
        }
    }
}


