using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddReputationEvent : Event {
    public int amount;
    public override void Call()
    {
        DialogeEngine.instance.ChangeReputation(amount);
    }

}
