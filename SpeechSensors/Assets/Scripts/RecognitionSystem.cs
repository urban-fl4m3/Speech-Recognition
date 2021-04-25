using System;
using System.Collections.Generic;
using UnityEngine;

public class RecognitionSystem
{
    public readonly RoomSensor[] Sensors;
    public readonly Microphone[] Microphones;

    private readonly Dictionary<Microphone, float> _lastTimeSignalReceived
        = new Dictionary<Microphone, float>();

    private float _timeElapsedSinceSignalReceived;
    private Microphone _firstMicrophoneGotSignal;
    
    public RecognitionSystem(RoomSensor[] sensors, Microphone[] microphones)
    {
        Sensors = sensors;
        Microphones = microphones;

        foreach (var microphone in microphones)
        {
            microphone.SignalReceived += HandleSignalReceived;

            foreach (var sensor in sensors)
            {
                if (Vector3.Distance(microphone.Position, sensor.Position) < microphone.Radius)
                {
                    microphone.AddSensor(sensor);
                }
            }
        }
    }

    private void HandleSignalReceived(object sender, EventArgs e)
    {
        var microphone = (Microphone) sender;

        if (_firstMicrophoneGotSignal == null)
        {
            _firstMicrophoneGotSignal = microphone;
            _timeElapsedSinceSignalReceived = Time.time;
        }
        
        if (_lastTimeSignalReceived.ContainsKey(microphone))
        {
            Debug.LogError("Multi sound is not supported!");
        }
        
        var level = _timeElapsedSinceSignalReceived / Time.time;
        
        _timeElapsedSinceSignalReceived = Time.time;
        _lastTimeSignalReceived.Add(microphone, _timeElapsedSinceSignalReceived);

        Debug.Log($"[Recognition System]: Microphone ({microphone.Name} got signal in" +
                  $" {_timeElapsedSinceSignalReceived}s) ");

        foreach (var sensor in microphone.RegionSensors)
        {
            sensor.React(level);
        }
        
        if (_lastTimeSignalReceived.Count == Microphones.Length)
        {
            CalculateSourcePosition();
        }
    }

    private void CalculateSourcePosition()
    {
        Debug.Log("CALCULATING SOURCE POSITION");
    }
}