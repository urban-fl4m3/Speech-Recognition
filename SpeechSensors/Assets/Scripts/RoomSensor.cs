using Components;

public class RoomSensor
{
    private readonly SensorComponent _sensorComponent;

    public RoomSensor(SensorComponent sensorComponent)
    {
        _sensorComponent = sensorComponent;
    }

    public void React(float level)
    {
        _sensorComponent.React(level);
    }
}