using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Event : MonoBehaviour {
    public Event next;
    public abstract void Call();
}
