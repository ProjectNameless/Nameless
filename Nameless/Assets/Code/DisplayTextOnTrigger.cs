using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayTextOnTrigger : TriggerColliderEvent {
    public string text;
    public float time;
    public override void Call()
    {
        base.Call();
        DialogeEngine.instance.StartDisplayTextInTime(text, time);
    }
}
