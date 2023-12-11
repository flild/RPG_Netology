#if UNITY_EDITOR
using UnityEngine;

namespace RPG
{
    public class LookAtCamGizmos : MonoBehaviour
    {
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.position, .1f);
        }

    }
}
#endif
