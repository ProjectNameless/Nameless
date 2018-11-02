using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue option", menuName = "Dialogue/option", order = 2)]
public class DialogueOptionSO : ScriptableObject {
    public string text;
    public DialogueSO[] nextDialogues;
    public string nextEvent;
    public void OnSelect(GameObject caller)
    {
        if (nextDialogues != null)
        DialogeEngine.instance.StartDisplayTextInTime(nextDialogues, caller);
        if (nextEvent != null)
        EventEngine.instance.Call(nextEvent);
    }
}
