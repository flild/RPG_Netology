using RPG.Units.Extensions;
using RPG.Weapons;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RPG.Units.Player
{
    [RequireComponent(typeof(Animator))]
    public class SwitchWeaponComponent : MonoBehaviour
    {
        private PlayerInputControl _playerInput;
        [SerializeField]
        private WeaponType _currentWeapon;
        [SerializeField]
        private Animator _animator;
        [SerializeField]
        private WeaponSet[] _weapons;
        private AnimationLayerManager _layerAnimManager;

        private int _IDIsEquipWeapon;
        private int _IDDisarm;

        private void Awake()
        {
            _IDDisarm = Animator.StringToHash("DisarmWeapon");
            _IDIsEquipWeapon = Animator.StringToHash("EquipWeapon");
            _layerAnimManager = new AnimationLayerManager(_animator);
            _playerInput = new PlayerInputControl();
            _playerInput.Enable();
            _playerInput.SwitchWeapon.FirstSlot.performed += FirstSlot;
            _playerInput.SwitchWeapon.SecondSlot.performed += SecondSlot;
            _playerInput.SwitchWeapon.ThirdSlot.performed += ThirdSlot;
            _playerInput.SwitchWeapon.disarm.performed += Disarm;

            _currentWeapon = WeaponType.None;

        }
        private void Start()
        {
            SwitchWeapon(WeaponType.None);
        }
        private void OnDisable()
        {
            _playerInput.SwitchWeapon.FirstSlot.performed -= FirstSlot;
            _playerInput.SwitchWeapon.SecondSlot.performed -= SecondSlot;
            _playerInput.SwitchWeapon.ThirdSlot.performed -= ThirdSlot;
            _playerInput.SwitchWeapon.disarm.performed -= Disarm;
            _playerInput.Disable();
        }
        private void OnValidate()
        {
            if (_animator == null)
                _animator = GetComponent<Animator>();
        }
        private void FirstSlot(InputAction.CallbackContext context)
        {
            SwitchWeapon(WeaponType.SwordAndShield);
        }
        private void SecondSlot(InputAction.CallbackContext context)
        {
            SwitchWeapon(WeaponType.Bow);
        }
        private void ThirdSlot(InputAction.CallbackContext context)
        {
            SwitchWeapon(WeaponType.Axe);
        }
        private void Disarm(InputAction.CallbackContext context)
        {
            SwitchWeapon(WeaponType.None);
        }
        private void SwitchWeapon(WeaponType type)
        {

            _layerAnimManager.LayerOn(type);
            _layerAnimManager.LayerOff(_currentWeapon);
            _animator.SetTrigger(_IDDisarm);
            foreach (var item in _weapons)
            {
                if (item.type == _currentWeapon)
                    item.weapon.DisableWeapon();
            }
            foreach (var item in _weapons)
            {
                if (item.type == type)
                    item.weapon.EnableWeapon();
            }
            _currentWeapon = type;
            _animator.SetTrigger(_IDIsEquipWeapon);
            //todo debug
        }
        [System.Serializable]
        internal struct WeaponSet
        {
            public WeaponType type;
            public Weapon weapon;
        }
    }
}

