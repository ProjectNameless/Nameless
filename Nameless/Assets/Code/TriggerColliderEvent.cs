using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerColliderEvent : Event {

    private void OnTriggerEnter(Collider other)
    {
        Call();
        GetComponent<Collider>().enabled = false;
    }
    public override void Call()
    {
        Debug.Log(gameObject.name + "was triggered");
    }
}
