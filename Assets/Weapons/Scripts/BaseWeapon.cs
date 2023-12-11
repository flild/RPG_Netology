using UnityEngine;

namespace RPG.Weapons
{
    [RequireComponent(typeof(Collider))]
    public abstract class BaseWeapon : MonoBehaviour
    {
        [SerializeField] protected Collider _collider;
        [SerializeField, Range(0, 50)] 
        public float _damage;
        [SerializeField, Range(0, 50)] 
        public float _attackCooldown;
        [SerializeField] private Units.BaseUnit _owner;
        private void OnEnable()
        {
            DisableCollider();
        }
        private void Reset()
        {
            if(_collider == null )
                _collider = GetComponent<Collider>();
            if (_owner == null)
                _owner = GetComponentInParent<Units.BaseUnit>();
            _collider.isTrigger = true;
        }
        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.TryGetComponent<Units.BaseUnit>(out Units.BaseUnit target))
            {
                Attack(target);
            }
        }
        public virtual void Attack(Units.BaseUnit target)
        {
            target.TakeDamage(_damage);
        }

        /// <summary>
        /// �������� ��������� ������(� ������ �����, ��������)
        /// </summary>
        public void EnableCollider()
        {
            _collider.enabled = true;
        }
        /// <summary>
        /// ��������� ��������� ������(� ������ ����� ����, ��������)
        /// </summary>
        public void DisableCollider()
        {
            _collider.enabled=false;
        }
    }
}

