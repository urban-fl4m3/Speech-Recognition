using System.Collections.Generic;
using Components;
using UnityEngine;

public class Room
{
    private readonly GameObject _roomObject;
    private readonly RoomSensor[] _sensors;
    private readonly Microphone[] _microphones;
    
    public Room(GameObject roomObject,
        IReadOnlyList<SensorComponent> sensorComponents,
        IReadOnlyList<MicrophoneComponent> microphoneComponents)
    {
        _roomObject = roomObject;

        var sensorsCount = sensorComponents.Count;
        _sensors = new RoomSensor[sensorsCount];

        for (var i = 0; i < sensorsCount; i++)
        {
            _sensors[i] = new RoomSensor(sensorComponents[i]);
        }

        var microphonesCount = microphoneComponents.Count;
        _microphones = new Microphone[microphonesCount];

        for (var i = 0; i < microphonesCount; i++)
        {
            _microphones[i] = new Microphone(microphoneComponents[i]);
        }
    }

    public override string ToString()
    {
        return $"Room: {_roomObject.name} / Sensors count: {_sensors.Length} / Microphones count: {_microphones.Length}";
    }
}