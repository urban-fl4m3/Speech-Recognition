using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(AudioSource))]
    public class AcousticComponent : SensorComponent
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _reactSound;
            
        public override void React(float level)
        {
            _audioSource.volume = level;
            _audioSource.PlayOneShot(_reactSound);
        }

        public override void Stop()
        {
            
        }
    }
}