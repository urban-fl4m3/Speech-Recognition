using UnityEngine;

public class Room
{
    private readonly GameObject _roomObject;
    private readonly SensorComponent[] _sensors;
    
    public Room(GameObject roomObject)
    {
        _roomObject = roomObject;

        _sensors = Object.FindObjectsOfType<SensorComponent>();
    }
}