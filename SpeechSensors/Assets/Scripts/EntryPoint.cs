using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private GameObject _roomObject;
    
    private void Start()
    {
        var room = new Room(_roomObject);
    }
}
