using System;
using System.Collections.Generic;
using Components;
using UnityEngine;

public class Microphone
{
    public event EventHandler SignalReceived;

    public string Name => _component.name;
    private readonly MicrophoneComponent _component;

    public float Radius => _component.Radius;
    public Vector3 Position => _component.transform.position;

    public List<RoomSensor> RegionSensors => _regionSensors;
    private List<RoomSensor> _regionSensors = new List<RoomSensor>();

    public Microphone(MicrophoneComponent component)
    {
        _component = component;
        _component.SignalReceived += HandleSignalReceived;
    }

    public void AddSensor(RoomSensor sensor)
    {
        _regionSensors.Add(sensor);
    }

    private void HandleSignalReceived(object sender, EventArgs e)
    {
        SignalReceived?.Invoke(this, EventArgs.Empty);    
    }
}