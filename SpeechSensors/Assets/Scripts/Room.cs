using System.Collections.Generic;
using Components;
using UnityEngine;

public class Room
{
    private readonly GameObject _roomObject;

    private readonly RecognitionSystem _recognitionSystem;
    
    public Room(GameObject roomObject,
        IReadOnlyList<SensorComponent> sensorComponents,
        IReadOnlyList<MicrophoneComponent> microphoneComponents)
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

        _recognitionSystem = new RecognitionSystem(sensors, microphones);
    }

    public override string ToString()
    {
        return $"Room: {_roomObject.name} / Sensors count: {_recognitionSystem.Sensors.Length} / Microphones count: " +
               $"{_recognitionSystem.Microphones.Length}";
    }
}