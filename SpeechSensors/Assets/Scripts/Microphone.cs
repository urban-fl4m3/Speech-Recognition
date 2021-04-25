using System;
using Components;

public class Microphone
{
    public event EventHandler SignalReceived;

    public string Name => _component.name;
    private readonly MicrophoneComponent _component;

    public Microphone(MicrophoneComponent component)
    {
        _component = component;
        _component.SignalReceived += HandleSignalReceived;
    }

    private void HandleSignalReceived(object sender, EventArgs e)
    {
        SignalReceived?.Invoke(this, EventArgs.Empty);    
    }
}