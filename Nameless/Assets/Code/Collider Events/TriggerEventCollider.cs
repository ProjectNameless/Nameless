using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEventCollider : MonoBehaviour{
    public bool Repeatable;
    public Event EventToCall;
    private void OnTriggerEnter(Collider other)
    {
        if (!Repeatable)
        GetComponent<Collider>().enabled = false;
        Debug.Log(gameObject.name + "was triggered");
        if (EventToCall != null)
            EventToCall.Call();
    }
}
