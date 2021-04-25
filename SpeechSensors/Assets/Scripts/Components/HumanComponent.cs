using System.Collections;
using UnityEngine;

namespace Components
{
    public class HumanComponent : MonoBehaviour
    {
        [SerializeField] private ReactColliderComponent _reactCollider;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _spreadSpeed;
        [SerializeField] private float _maxRadius;

        private float _radius;
        
        public void PushSignal()
        {
            _rigidbody.MovePosition(transform.position);
            
            _reactCollider.gameObject.SetActive(true);
            StartCoroutine(SpreadSignal());
        }

        private IEnumerator SpreadSignal()
        {
            _radius = .0f;
            
            while (_radius <= _maxRadius)
            {
                _radius += _spreadSpeed * Time.deltaTime;
                _reactCollider.Radius = _radius;
                yield return null;
            }

            _reactCollider.gameObject.SetActive(false);
            _radius = 0.0f;
        }

        private void OnDrawGizmos()
        {
            if (EntryPoint.EnableDebugMode || Application.isEditor)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(transform.position, _radius);
            }
        }
    }
}
