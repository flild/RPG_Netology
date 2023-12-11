
using UnityEngine;

namespace RPG.Units
{
    [RequireComponent(typeof(UnitMoveComponent),typeof(UnitStats),typeof(View.UnitViewComponent))]
    public class BaseUnit : MonoBehaviour
    {
        [SerializeField] protected UnitMoveComponent _moveComponent;
        [SerializeField] protected View.UnitViewComponent _view;
        [SerializeField] protected UnitStats _stats;

        public BaseUnit target { get; protected set; }

        public void TakeDamage(float amount)
        {
            _stats.Currenthealth -= amount;
            Debug.Log($"Unit {gameObject.name} get {amount} damage");
            if (amount > 0 && !CheckOnDeath())
                _view.TakeDamageAnim();
            
        }
        public void TakeShieldStun(float duration)
        {
            _view.TakeShieldStun();
        }
        private bool CheckOnDeath()
        {
            if (_stats.Currenthealth <= 0)
            {
                Death();
                return true;
            }
            else
            {
                return false;
            }
                
        }
        public virtual void Death()
        {
            _moveComponent.UnitInAnimation();
            _view.DeathAnim();
            Debug.Log($"Unit {gameObject.name} die");
        }
        public string ShowFocusInfo()
        {
            return string.Concat(_stats.unitName,"\n",_stats.Currenthealth,"/",_stats.MaxHealth);
        }

        public UI.FocusType GetFocusType()
        {
            return UI.FocusType.Unit;
        }

    }
}

