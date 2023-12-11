using RPG.Units.View;
using UnityEngine;

namespace RPG.Units.Player
{
    public class PlayerViewComponent : UnitViewComponent
    {
        private int _IDIsCrouch;
        private int _IDIsSprint;
        protected override void Awake()
        {
            base.Awake();
            _IDIsCrouch = Animator.StringToHash("Crouch");
            _IDIsSprint = Animator.StringToHash("Sprint");
        }

        public void CrouchAnim(bool isOn)
        {
            _MoveAnimator.SetBool(_IDIsCrouch, isOn);
        }
        public void SprintAnim(bool isOn)
        {
            _MoveAnimator.SetBool(_IDIsSprint, isOn);
        }
    }
}

