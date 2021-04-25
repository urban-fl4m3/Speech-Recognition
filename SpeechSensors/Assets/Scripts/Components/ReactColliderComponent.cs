using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(SphereCollider))]
    public class ReactColliderComponent : MonoBehaviour
    {
        [SerializeField] private SphereCollider _collider;

        public float Radius
        {
            set => _collider.radius = value;
        }
    }
}