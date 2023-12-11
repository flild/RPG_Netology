
using RPG.Units.Extensions;
using UnityEngine;

namespace RPG.Units
{
    public class Enemy : BaseUnit, IFocusable
    {
        public SideType GetSide()
        {
            return _stats.side;
        }
    }
}

