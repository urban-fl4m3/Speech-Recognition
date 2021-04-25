using Components;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private GameObject _roomObject;
    
    private void Start()
    {
        var sensors = FindObjectsOfType<SensorComponent>();
        var microphones = FindObjectsOfType<MicrophoneComponent>();
        var room = new Room(_roomObject, sensors, microphones);
        
        Debug.Log(room.ToString());
    }
}
