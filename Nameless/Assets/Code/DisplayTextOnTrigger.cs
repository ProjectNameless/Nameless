using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayTextOnTrigger : TriggerColliderEvent {
    public DialogueSO[] dialogue;
    public override void Call()
    {
        base.Call();
        DialogeEngine.instance.StartDisplayTextInTime(dialogue, gameObject);
    }
}
