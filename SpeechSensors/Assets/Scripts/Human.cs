using Components;

public class Human
{
    private readonly HumanComponent _component;

    public Human(HumanComponent component)
    {
        _component = component;
    }

    public void PushSignal()
    {
        _component.PushSignal();
    }
}
