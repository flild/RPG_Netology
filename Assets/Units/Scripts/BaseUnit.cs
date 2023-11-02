
using UnityEngine;

namespace RPG.Units
{
    [RequireComponent(typeof(UnitMoveComponent),typeof(UnitStats))]
    public class BaseUnit : MonoBehaviour
    {
        protected UnitMoveComponent _moveComponent;
    }
}

