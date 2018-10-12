using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogeEngine : MonoBehaviour {
    private Text Captions;
    private GameObject TextBox;
    #region singleton
    public static DialogeEngine instance;
    private void Awake()
    {
        if (instance == null || instance == this)
            instance = this;
        else
            Destroy(this);
    }
    #endregion
    // Use this for initialization
    void Start () {
        Captions = GameObject.FindGameObjectWithTag("Captions").GetComponent<Text>();
        TextBox = GameObject.FindGameObjectWithTag("Text Box");
	}
    /// <summary>
    /// displays whole string within time specified. letters per second = text.length/time
    /// </summary>
    /// <param name="text"></param>
    /// <param name="time"></param>
	public void StartDisplayTextInTime(string text, float time)
    {
        StartCoroutine(DisplayTextInTime(text, time));
    }
    private IEnumerator DisplayTextInTime(string text, float time)
    {
        TextBox.SetActive(true);
        int lettersPerSecond = Mathf.RoundToInt((text.Length - 1) / time);
        int letterIndex = 0;
        Captions.text = "";
        while((Captions.text.Length-1 < text.Length-1) && (!Input.GetKeyDown(KeyCode.Return)))
        {
            Captions.text += text[letterIndex];
            yield return new WaitForSeconds(lettersPerSecond);
        }
        Captions.text = text;
        yield return new WaitForSeconds(time);
        Captions.text = "";
        TextBox.SetActive(false);
    }
}
