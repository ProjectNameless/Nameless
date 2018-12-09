using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour {
    public GameObject QuestGiver;
    public List<Goal> goals = new List<Goal>();
    public Event OnCompletion;
    public Text display;
	// Use this for initialization
    public void Init(GameObject questGiver)
    {
        InvokeRepeating("UpdateProgress", 1, 1);
        QuestGiver = questGiver;
    }
    private void UpdateProgress()
    {
        List<Goal> goalsToRemove = new List<Goal>();
        foreach (Goal goal in goals)
        {
            if (goal.task.calls >= goal.required)
                goalsToRemove.Add(goal);
        }
        UpdateUI();
        foreach (Goal goal in goalsToRemove)
            goals.Remove(goal);
        if (goals.Count == 0)
        {
            if(OnCompletion != null)
            OnCompletion.Call();
            UpdateUI();
            Destroy(this);
        }
    }
    private void UpdateUI()
    {
        string text = "";
        foreach (Goal goal in goals)
        {
            text += goal.task.name + " " + goal.task.calls + "/" + goal.required + "\n";
        }
        display.text = text;
    }
}
