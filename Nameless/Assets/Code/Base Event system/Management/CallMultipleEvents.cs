using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallMultipleEvents : Event
{
    [SerializeField]
    public List<Event> eventsToCall = new List<Event>();
    public override void Call()
    {
        base.Call();
        foreach (Event _Event in eventsToCall)
        {
            if (gameObject.GetComponent<Quest>() != null)
            {
                if (_Event is ChangeDialogueEvent)
                    ((ChangeDialogueEvent)_Event).targetGO = gameObject.GetComponent<Quest>().QuestGiver;
            }
            _Event.Call();
        }
    }
}
