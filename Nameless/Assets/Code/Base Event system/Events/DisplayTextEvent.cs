using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayTextEvent : Event {
    public DialogueSO[] dialogue;
    public override void Call()
    {
        DialogeEngine.instance.StartDisplayTextInTime(dialogue, gameObject);
        if (next != null) next.Call();
    }
}
