using RPG.Units;
using UnityEngine;

namespace RPG.Weapons.Shield
{
    public class DefaultShield : BaseShield, Interfaces.IShield
    {
        [SerializeField] private float _StunDuration;
        public override void Attack(BaseUnit target)
        {
            base.Attack(target);
            target.TakeShieldStun(_StunDuration);
        }
    }
}

