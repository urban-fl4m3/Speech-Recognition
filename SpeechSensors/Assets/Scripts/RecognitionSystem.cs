using System;
using System.Collections.Generic;
using UnityEngine;

public class RecognitionSystem
{
    public readonly RoomSensor[] Sensors;
    public readonly Microphone[] Microphones;

    private readonly Dictionary<Microphone, float> _lastTimeSignalReceived
        = new Dictionary<Microphone, float>();
    
    public RecognitionSystem(RoomSensor[] sensors, Microphone[] microphones)
    {
        Sensors = sensors;
        Microphones = microphones;

        foreach (var microphone in microphones)
        {
            microphone.SignalReceived += HandleSignalReceived;
        }
    }

    private void HandleSignalReceived(object sender, EventArgs e)
    {
        var microphone = (Microphone) sender;

        if (_lastTimeSignalReceived.ContainsKey(microphone))
        {
            Debug.LogError("Multi sound is not supported!");
        }

        var time = Time.time;
        _lastTimeSignalReceived.Add(microphone, time);
        
        Debug.Log($"[Recognition System]: Microphone ({microphone.Name} got signal in {time}s) ");

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