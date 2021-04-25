using Components;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    public static bool EnableDebugMode { get; private set; }
    
    [SerializeField] private bool _enableDebugMod;
    [SerializeField] private GameObject _roomObject;
    [SerializeField] private HumanComponent _humanComponent;
    
    private void Start()
    {
        EnableDebugMode = _enableDebugMod;
        
        var sensors = FindObjectsOfType<SensorComponent>();
        var microphones = FindObjectsOfType<MicrophoneComponent>();
        var room = new Room(_roomObject, sensors, microphones);

        var human = new Human(_humanComponent);
        human.PushSignal();
        
        Debug.Log(room.ToString());
    }
}
