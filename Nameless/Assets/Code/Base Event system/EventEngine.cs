using System;
using System.Collections.Generic;
using UnityEngine;

public class EventEngine : MonoBehaviour {

    public static EventEngine instance;
    public List<Event> events = new List<Event>();
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }
    public void Call(string name)
    {
        Array.Find(events.ToArray(), searchevent => searchevent.name == name).Call();
    }
}
