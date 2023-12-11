using UnityEngine;

namespace RPG.Weapons
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField]
        private Renderer _mesh;
        public void EnableWeapon()
        {
            
            _mesh.enabled = true;
        }
        public void DisableWeapon()
        { 
            _mesh.enabled = false;
        }
    }
}

