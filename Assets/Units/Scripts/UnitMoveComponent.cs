using RPG.Units.Player;
using UnityEngine;

namespace RPG.Units
{
    [RequireComponent(typeof(Rigidbody),typeof(View.UnitViewComponent), typeof(UnitStats))]
    public class UnitMoveComponent : MonoBehaviour
    {
        private Rigidbody _rb;
        private UnitStats _stats;
        private View.UnitViewComponent _view;
        private PlayerState _states;
        [SerializeField]
        private bool _inAnimation = false;
        //jump
        private float _Yspeed;
        private bool _isGrounded = true;
        private const int _jumpRatio = 100;
        private const int _moveSpeedRatio = 100;

        private Vector3 calcDirection;

        #region Unity Callbacks
        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _view = GetComponent<View.UnitViewComponent>();
            _stats = GetComponent<UnitStats>();
            _states = GetComponent<PlayerState>();
        }
        private void FixedUpdate()
        {
            CheckYSpeed();
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (_isGrounded) return;
            //todo чуть более гибкая проверка нормали, прыжки от косых поверхностей
            if (collision.contacts[0].normal == Vector3.up)
            {
                _isGrounded = true;
                _view.LandingAnim();
            }
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            if(calcDirection !=null)
            {
                Gizmos.DrawLine(transform.position, transform.position + calcDirection*3);
            }
            
        }
        #endregion
        public void Move(Vector3 direction)
        {
            if (_inAnimation)
                return;
            if (_isGrounded)
            {
                calcDirection = transform.forward * direction.z + transform.right * direction.x;
                if(_states.isSprinting)
                {
                    _rb.velocity = calcDirection * _stats.SprintSpeed * Time.deltaTime * _moveSpeedRatio;
                }
                else
                { 
                    _rb.velocity = calcDirection * _stats.moveSpeed * Time.deltaTime * _moveSpeedRatio;
                }
                    
                _view.MoveAnim(direction);
            }
                
        }
        #region Jump
        public void Jump()
        {
            if (_isGrounded)
            {
                _view.JumpAnim();
                _rb.AddForce(Vector3.up * _stats.jumpHight * _jumpRatio, ForceMode.Impulse);
                _isGrounded = false;
            }

        }
        public void CheckYSpeed()
        {
            _Yspeed = _rb.velocity.y;
            if (_Yspeed < -1)
            {
                _view.FallAnim();
            }

        } 
        #endregion
        public void OnEndAnyAnimation()
        {
            _inAnimation = false;
           
        }
        public void UnitInAnimation()
        {
            _inAnimation = true;
        }
        public void SwordAttack()
        {
            if (_inAnimation || !_isGrounded)
                return;
            _inAnimation = true;
            _view.SwordAttackAnim();
        }
        public void ShieldAttack()
        {
            if (_inAnimation || !_isGrounded)
                return;
            _inAnimation = true;
            _view.ShieldAttackAnim();
        }
    }
}

