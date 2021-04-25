using UnityEngine;

namespace Components
{
    public abstract class SensorComponent : MonoBehaviour
    {
        public abstract void React(float level);
        public abstract void Stop();
    }
}