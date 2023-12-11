using RPG.Weapons.Interfaces;
using UnityEngine;
namespace RPG.Units.Player
{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerUnit : BaseUnit
    {
        private PlayerInput _playerInput;
        private Vector3 _directionMove;
        private Vector2 _rotateDirection;
        [SerializeField] private LookAtCamGizmos _lookpoint;
        [SerializeField] private IShield _shield;
        [SerializeField] private ImeeleRHandWeapon _weapon;
        private Transform _cameraPivot;

        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
            _shield = GetComponentInChildren<IShield>();
            _weapon = GetComponentInChildren<ImeeleRHandWeapon>();
            _cameraPivot = Camera.main.GetComponentInParent<CameraComponent>().pivot;
        }
        private void FixedUpdate()
        {
            _directionMove = _playerInput.GetMoveDirection();
            _moveComponent.Move(_directionMove);
        }
        private void LateUpdate()
        {
            Rotate();
        }
        private void Reset()
        {
            if (_stats == null)
                _stats = GetComponent<UnitStats>();
            if (_moveComponent == null)
                _moveComponent = GetComponent<UnitMoveComponent>();
            if (_view == null)
                _view = GetComponent<View.UnitViewComponent>();
            if (_shield == null)
                _shield = GetComponentInChildren<IShield>();
            if (_weapon == null)
                _weapon = GetComponentInChildren<ImeeleRHandWeapon>();
        }
        private void Rotate()
        {
            transform.LookAt(_lookpoint.transform);
        }
        public void OnWeaponAttack(AnimationEvent data)
        {
            switch (data.intParameter)
            {
                case 0:
                    _weapon.DisableCollider();
                    break;
                case 1:
                    _weapon.EnableCollider();
                    break;
            }
        }
        public void OnShieldAttack(AnimationEvent data)
        {
            switch (data.intParameter)
            {
                case 0:
                    _shield.DisableCollider();
                    break;
                case 1:
                    _shield.EnableCollider();
                    break;
            }
        }

    }

}
