using Components;
using UnityEngine;

public class Human
{
    public Vector3 Position => _component.transform.position;
    private readonly HumanComponent _component;

    public float SpreadSpeed => _component.SpreadSpeed;
    
    public Human(HumanComponent component)
    {
        _component = component;
    }

    public void PushSignal()
    {
        _component.PushSignal();
    }

    public void ChangePosition(Vector3 pos)
    {
        _component.transform.position = pos;
    }
}
