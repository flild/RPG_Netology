using UnityEngine;
using UnityEngine.InputSystem;

namespace RPG.Units.Player
{
    [RequireComponent(typeof(AnimStateMachine))]
    public class PlayerInput : MonoBehaviour
    {
        private PlayerInputControl _playerInput;
        private UnitMoveComponent _moveComponent;
        private PlayerState _states;
        private AnimStateMachine _stateMachine;
        private void Awake()
        {
            _moveComponent = GetComponent<UnitMoveComponent>();
            _states = GetComponent<PlayerState>();
        }
        private void OnEnable()
        {
            _playerInput = new PlayerInputControl();
            _playerInput.Enable();
            _playerInput.MoveMap.Jump.performed += OnJump;
            _playerInput.MoveMap.RHandAttack.performed += SwordAttack;
            _playerInput.MoveMap.LHandAttack.performed += ShieldAttack;
            _playerInput.MoveMap.Crouch.started += OnStartCrouch;
            _playerInput.MoveMap.Crouch.canceled += OnEndCrouch;
            _playerInput.MoveMap.Sprint.started += OnStartSprint;
            _playerInput.MoveMap.Sprint.canceled += OnEndSprint;

        }
        public Vector3 GetMoveDirection()
        {
            var input = _playerInput.MoveMap.Move.ReadValue<Vector2>();
            if(input.y == 0 && input.x == 0)
            {
                _states.isMove = false;
            }
            else
            {
                _states.isMove = true;
            }
            Vector3 direction = new Vector3(input.x, 0,input.y);
            return direction;

        }
        public Vector2 GetMouseDelta()
        {
            var delta = _playerInput.MoveMap.Delta.ReadValue<Vector2>();
            return delta;
        }
        private void OnStartCrouch(InputAction.CallbackContext context)
        {
            _states.isCrouching = true;
        }
        private void OnEndCrouch(InputAction.CallbackContext context)
        {
            _states.isCrouching = false;
        }
        private void OnStartSprint(InputAction.CallbackContext context)
        {
            _states.isSprinting = true;
        }
        private void OnEndSprint(InputAction.CallbackContext context)
        {
            _states.isSprinting = false;
        }

        private void OnJump(InputAction.CallbackContext context)
        {
            _moveComponent.Jump();
        }
        private void SwordAttack(InputAction.CallbackContext context)
        {
            _moveComponent.SwordAttack();
        }
        private void ShieldAttack(InputAction.CallbackContext context)
        {
            _moveComponent.ShieldAttack();
        }
        private void OnDisable()
        {
            _playerInput.MoveMap.Jump.performed -= OnJump;
            _playerInput.MoveMap.RHandAttack.performed -= SwordAttack;
            _playerInput.MoveMap.LHandAttack.performed -= ShieldAttack;
            _playerInput.MoveMap.Crouch.started -= OnStartCrouch;
            _playerInput.MoveMap.Crouch.canceled -= OnEndCrouch;
            _playerInput.MoveMap.Sprint.started -= OnStartSprint;
            _playerInput.MoveMap.Sprint.canceled -= OnEndSprint;
            _playerInput.Disable();
        }
    }

}
