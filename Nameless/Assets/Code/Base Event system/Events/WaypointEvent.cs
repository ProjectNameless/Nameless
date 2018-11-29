using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointEvent : Event {
    public int required;
    public override void Call()
    {
        base.Call();
        if (calls >= required)
        {
            Destroy(gameObject, 1.5f);
        }
    }
}
