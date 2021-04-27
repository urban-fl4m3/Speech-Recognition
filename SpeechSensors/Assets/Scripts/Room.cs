using System.Collections.Generic;
using Agents;
using Components;
using UnityEngine;

public class Room
{
    private readonly GameObject _roomObject;

    public RecognitionSystem System { get; }

    public Room(GameObject roomObject,
        IReadOnlyList<SensorComponent> sensorComponents,
        IReadOnlyList<MicrophoneComponent> microphoneComponents,
        MlAgent agent, EntryPoint point)
    {
        _roomObject = roomObject;

        var sensorsCount = sensorComponents.Count;
        var sensors = new RoomSensor[sensorsCount];

        for (var i = 0; i < sensorsCount; i++)
        {
            sensors[i] = new RoomSensor(sensorComponents[i]);
        }

        var microphonesCount = microphoneComponents.Count;
        var microphones = new Microphone[microphonesCount];

        for (var i = 0; i < microphonesCount; i++)
        {
            microphones[i] = new Microphone(microphoneComponents[i]);
        }

        System = new RecognitionSystem(sensors, microphones, agent, point);
    }

    public override string ToString()
    {
        return $"Room: {_roomObject.name} / Sensors count: {System.Sensors.Length} / Microphones count: " +
               $"{System.Microphones.Length}";
    }
}