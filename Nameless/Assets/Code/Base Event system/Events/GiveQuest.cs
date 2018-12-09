using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveQuest : Event{

    public GameObject questGO;

    public override void Call()
    {
        base.Call();
        GameObject newQuestGO = Instantiate(questGO, questGO.transform.position, questGO.transform.rotation);
        Quest quest = newQuestGO.GetComponent<Quest>();
        quest.Init(gameObject);
    }

}
