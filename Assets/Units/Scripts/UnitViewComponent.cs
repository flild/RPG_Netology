using RPG.Units.Player;
using UnityEngine;

namespace RPG.Units.View
{
    public class UnitViewComponent : MonoBehaviour
    {
        [SerializeField] protected Animator _MoveAnimator;
        private int _IDForwardMove;
        private int _IDSideMove;
        protected int _IDIsMoving;
        private int _IDIsJumping;
        private int _IDIsFalling;
        private int _IDIsGrounded;
        private int _IDIsSwordAttack;
        private int _IDIsShieldAttack;
        private int _IDIsDie;
        private int _IDIsTakeDamage;
        private int _IDIsTakeShieldStun;

        protected virtual void Awake()
        {
            _IDForwardMove = Animator.StringToHash("ForwardMove");
            _IDSideMove = Animator.StringToHash("SideMove");
            _IDIsMoving = Animator.StringToHash("IsMoving");
            _IDIsJumping = Animator.StringToHash("IsJumping");
            _IDIsFalling = Animator.StringToHash("IsFalling");
            _IDIsGrounded = Animator.StringToHash("IsGrounded");
            _IDIsSwordAttack = Animator.StringToHash("SwordAttack");
            _IDIsShieldAttack = Animator.StringToHash("ShieldAttack");
            _IDIsTakeDamage = Animator.StringToHash("TakeDamage");
            _IDIsTakeShieldStun = Animator.StringToHash("TakeShieldStun");
            _IDIsDie = Animator.StringToHash("Die");
            
        }

        //todo
        public void MoveAnim(Vector3 direction)
        {
            _MoveAnimator.SetFloat(_IDForwardMove, direction.z);
            _MoveAnimator.SetFloat(_IDSideMove, direction.x);
            if(direction.x == 0 && direction.z == 0)
            {
                _MoveAnimator.SetBool(_IDIsMoving, false);
            }
            else
            {
                _MoveAnimator.SetBool(_IDIsMoving, true);
            }
        }
        public void SwordAttackAnim()
        {
            _MoveAnimator.SetTrigger(_IDIsSwordAttack);
        }
        public void ShieldAttackAnim()
        {
            _MoveAnimator.SetTrigger(_IDIsShieldAttack);
        }
        public void TakeDamageAnim()
        {
            _MoveAnimator.SetTrigger(_IDIsTakeDamage);
        }
        public void TakeShieldStun()
        {
            _MoveAnimator.SetTrigger(_IDIsTakeShieldStun);
        }
        public void DeathAnim()
        {
            _MoveAnimator.SetTrigger(_IDIsDie);
        }
        #region JumpAnimation
        public void JumpAnim()
        {
            _MoveAnimator.SetBool(_IDIsJumping, true);
            _MoveAnimator.SetBool(_IDIsFalling, false);
            _MoveAnimator.SetBool(_IDIsGrounded, false);
        }
        public void FallAnim()
        {
            _MoveAnimator.SetBool(_IDIsJumping, false);
            _MoveAnimator.SetBool(_IDIsFalling, true);
            _MoveAnimator.SetBool(_IDIsGrounded, false);
        }
        public void LandingAnim()
        {
            _MoveAnimator.SetBool(_IDIsJumping, false);
            _MoveAnimator.SetBool(_IDIsFalling, false);
            _MoveAnimator.SetBool(_IDIsGrounded, true);
        } 
        #endregion

    }

}
