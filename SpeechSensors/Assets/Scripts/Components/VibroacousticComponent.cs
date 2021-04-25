using UnityEngine;

namespace Components
{
    public class VibroacousticComponent : SensorComponent
    {
        public override void React(float level)
        {
            Debug.Log($"Vibrating with {level} level.");
        }

        public override void Stop()
        {
            
        }
    }
}