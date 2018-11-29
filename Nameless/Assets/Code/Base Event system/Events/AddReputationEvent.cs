using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddReputationEvent : Event {
    public int amount;
    public override void Call()
    {
        base.Call();
        if (DialogeEngine.instance != null)
            DialogeEngine.instance.ChangeReputation(amount);
        else
            Debug.LogWarning("This scene lacks a DialogeEngine. Reputation is currently tied to the DialogeEngine.");
    }

}
