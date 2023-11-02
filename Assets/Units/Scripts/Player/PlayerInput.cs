using UnityEngine;
using UnityEngine.InputSystem;

namespace RPG.Units.Player
{
    public class PlayerInput : MonoBehaviour
    {
        private PlayerInputControl _playerInput;
        private UnitMoveComponent _moveComponent;
        private void Awake()
        {
            _moveComponent = GetComponent<UnitMoveComponent>();
        }
        private void OnEnable()
        {
            _playerInput = new PlayerInputControl();
            _playerInput.Enable();
            _playerInput.MoveMap.Jump.performed += OnJump;
            _playerInput.MoveMap.RHandAttack.performed += OnSwordAttack;
            _playerInput.MoveMap.LHandAttack.performed += OnShieldAttack;

        }
        public Vector3 GetMoveDirection()
        {
            var input = _playerInput.MoveMap.Move.ReadValue<Vector2>();
            
            Vector3 direction = new Vector3(input.x, 0,input.y);
            
            return direction;

        }
        private void OnJump(InputAction.CallbackContext context)
        {
            _moveComponent.Jump();
        }
        private void OnSwordAttack(InputAction.CallbackContext context)
        {
            _moveComponent.SwordAttack();
        }
        private void OnShieldAttack(InputAction.CallbackContext context)
        {
            _moveComponent.ShieldAttack();
        }
        private void OnDisable()
        {
            _playerInput.MoveMap.Jump.performed -= OnJump;
            _playerInput.MoveMap.RHandAttack.performed -= OnSwordAttack;
            _playerInput.MoveMap.LHandAttack.performed -= OnShieldAttack;
            _playerInput.Disable();
        }
    }

}
