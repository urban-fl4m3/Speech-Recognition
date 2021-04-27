using UnityEngine;
using Components;

public class RoomSensor
{
    public bool Enabled { get; set; }

    public Vector3 Position => _sensorComponent.transform.position;
    
    private readonly SensorComponent _sensorComponent;

    public RoomSensor(SensorComponent sensorComponent)
    {
        _sensorComponent = sensorComponent;
    }

    public void React(float level)
    {
       // _sensorComponent.React(level);
    }
}