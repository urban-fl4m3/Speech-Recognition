using UnityEngine;

namespace Components
{
    public class MicrophoneComponent : MonoBehaviour
    {
        [SerializeField] private float _radius;

        public float Radius => _radius;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(transform.position, _radius);
        }
    }
}