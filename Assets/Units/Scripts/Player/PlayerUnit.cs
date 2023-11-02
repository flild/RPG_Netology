
using UnityEngine;
namespace RPG.Units.Player
{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerUnit : BaseUnit
    {
        private PlayerInput _playerInput;
        private Vector3 _directionMove;

        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
            _moveComponent = GetComponent<UnitMoveComponent>();
            
        }

        private void FixedUpdate()
        {
            _directionMove = _playerInput.GetMoveDirection();
            _moveComponent.Move(_directionMove);
            
        }
    }

}
