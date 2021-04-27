using System;
using UnityEngine;

namespace Components
{
    public class MicrophoneComponent : MonoBehaviour
    {
        public event EventHandler SignalReceived;
        
        [SerializeField] private float _radius;
        [SerializeField] private bool _enableEditorDebug;

        public float Radius => _radius;

        private void OnDrawGizmos()
        {
            if ((EntryPoint.EnableDebugMode || Application.isEditor) && _enableEditorDebug)
            {
                Gizmos.color = Color.magenta;
                Gizmos.DrawWireSphere(transform.position, _radius);
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Signal"))
            {
                SignalReceived?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}