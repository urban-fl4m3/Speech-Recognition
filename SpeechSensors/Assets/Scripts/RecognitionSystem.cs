using System;
using System.Collections.Generic;
using System.Linq;
using Agents;
using UnityEngine;

public class RecognitionSystem
{
    public event EventHandler SensorsGotSignals;
    
    public readonly RoomSensor[] Sensors;
    public readonly Microphone[] Microphones;
    private readonly EntryPoint _point;
    
    public MlAgent Agent { get; }

    private readonly Dictionary<Microphone, float> _lastTimeSignalReceived
        = new Dictionary<Microphone, float>();

    private float _timeElapsedSinceSignalReceived;
    private Microphone _firstMicrophoneGotSignal;
    
    public RecognitionSystem(RoomSensor[] sensors, Microphone[] microphones, MlAgent agent, EntryPoint point)
    {
        Sensors = sensors;
        Microphones = microphones;
        _point = point;
        Agent = agent;

        foreach (var microphone in microphones)
        {
            // microphone.SignalReceived += HandleSignalReceived;

            foreach (var sensor in sensors)
            {
                if (Vector3.Distance(microphone.Position, sensor.Position) < microphone.Radius)
                {
                    microphone.AddSensor(sensor);
                }
            }
        }
    }

    public void ReactAllMics(float soundSpeed, Vector3 origin)
    {
        _lastTimeSignalReceived.Clear();
        
        foreach (var microphone in Microphones)
        {
            var dist = Vector3.Distance(microphone.Position, origin);
            var t = dist / soundSpeed;
        
            var level = t / _point.ElapsedTimeFromRoundStart;
        
            // Debug.Log($"[Recognition System]: Microphone ({microphone.Name} got signal in" +
                     // $" {t}s) ");

            foreach (var sensor in microphone.RegionSensors)
            {
                sensor.React(level);
            }
            
            _lastTimeSignalReceived.Add(microphone, t);
        }

        CalculateSourcePosition();
    }
    
    private void CalculateSourcePosition()
    {
        SensorsGotSignals?.Invoke(this, EventArgs.Empty);
        
        Agent.enabled = true;

        var values = _lastTimeSignalReceived.Select(k => k.Value).ToList();
        Agent.AddObservations(values);
    }
}