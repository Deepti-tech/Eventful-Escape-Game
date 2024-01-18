using System

public class EventController{
    pubic Action baseEvent;
    public void AddListener (Action listener) => baseEvent+=listener;
    public void RemoveListener (Action listener) => baseEvent-=listener;
    public void InvokeEvent() => baseEvent?.Invoke();
}