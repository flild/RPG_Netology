using System.Collections.Generic;
using UnityEngine;

namespace RPG.Units.Extensions
{
    public enum SideType
    {
        None,
        Enemy,
        friendly,
        neutral
    }
    public enum WeaponType
    {
        None,
        SwordAndShield,
        Bow,
        Axe
    }
    public class AnimationLayerManager
    {
        private Animator _playerAnimator;
        private Dictionary<WeaponType, int> layerIds;
        public AnimationLayerManager(Animator animator)
        {
            _playerAnimator = animator;
            layerIds = new Dictionary<WeaponType, int>();
            layerIds[WeaponType.None] = _playerAnimator.GetLayerIndex("Unarmed");
            layerIds[WeaponType.SwordAndShield] = _playerAnimator.GetLayerIndex("SwordAndShield");
            layerIds[WeaponType.Bow] = _playerAnimator.GetLayerIndex("Bow");
            layerIds[WeaponType.Axe] = _playerAnimator.GetLayerIndex("Axe");
        }
        public void LayerOn(WeaponType type)
        {
            _playerAnimator.SetLayerWeight(layerIds[type], 1);

        }
        public void LayerOff(WeaponType type)
        {
            _playerAnimator.SetLayerWeight(layerIds[type], 0);

        }

    }
}

