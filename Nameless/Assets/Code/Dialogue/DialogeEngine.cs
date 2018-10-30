using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogeEngine : MonoBehaviour {
    private Text Captions;
    private GameObject TextBox;
    private GameObject player;
    public AudioClip[] interuptionMessages;
    public GameObject interuptionPrefab;
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
        player = GameObject.FindGameObjectWithTag("Player");
	}
    /// <summary>
    /// displays whole string within time specified. letters per second = text.length/time
    /// </summary>
    /// <param name="text"></param>
    /// <param name="time"></param>
	public void StartDisplayTextInTime(DialogueSO[] dialogues, GameObject caller)
    {
        StopAllCoroutines();
        StartCoroutine(DisplayTextInTime(dialogues, caller));
    }
    private IEnumerator DisplayTextInTime(DialogueSO[] dialogues, GameObject caller)
    {
        foreach (DialogueSO dialogue in dialogues)
        {
            TextBox.SetActive(true);
            if (dialogue is DialogueWithAudioSO)
            {
                AudioSource audioSource;
                DialogueWithAudioSO dialogueWithAudio = ((DialogueWithAudioSO)dialogue);
                audioSource = caller.GetComponent<AudioSource>();
                AudioClip soundClip = dialogueWithAudio.voice;
                audioSource.clip = soundClip;
                audioSource.Play();
                float lettersPerSecond = (dialogue.text.Length - 1) / soundClip.length * dialogueWithAudio.time;
                int letterIndex = 0;
                Captions.text = "";
                while ((Captions.text.Length < dialogue.text.Length) && (!Input.GetKeyDown(KeyCode.Return)))
                {
                    Captions.text += dialogue.text[letterIndex];
                    letterIndex++;
                    yield return new WaitForSeconds(1 / lettersPerSecond);
                    if (dialogueWithAudio.interuptable)
                    {
                        bool interupted = false;
                        AudioSource interuptingAudioSource = null;
                        while (Vector3.Distance(player.transform.position, caller.transform.position) > audioSource.maxDistance / 2)
                        {
                            audioSource.Pause();
                            if (!interupted)
                            {
                                interuptingAudioSource = GameObject.Instantiate(interuptionPrefab, caller.transform).GetComponent<AudioSource>();
                                interuptingAudioSource.clip = interuptionMessages[0];
                                interuptingAudioSource.Play();
                                interupted = true;
                            }
                            yield return null;
                        }
                        if (interupted && interuptingAudioSource != null)
                        {
                            interuptingAudioSource.clip = interuptionMessages[1];
                            interuptingAudioSource.Play();
                            while (interuptingAudioSource.isPlaying)
                            {
                                yield return null;
                            }
                            Destroy(interuptingAudioSource.gameObject);
                            audioSource.Play();
                        }
                    }
                }
                Captions.text = dialogue.text;
                while (audioSource.isPlaying)
                    yield return null;
            }
            else
            {
                float lettersPerSecond = (dialogue.text.Length - 1) / dialogue.time;
                int letterIndex = 0;
                Captions.text = "";
                while ((Captions.text.Length - 1 < dialogue.text.Length - 1) && (!Input.GetKeyDown(KeyCode.Return)))
                {
                    Captions.text += dialogue.text[letterIndex];
                    letterIndex++;
                    yield return new WaitForSeconds(1 / lettersPerSecond);
                }
                Captions.text = dialogue.text;
                float timeTillExpire = dialogue.time;
                yield return null;
                while (timeTillExpire > 0 && !Input.GetKeyDown(KeyCode.Return))
                {
                    yield return null;
                    timeTillExpire -= Time.deltaTime;
                }
            }
            Captions.text = "";
        }
        TextBox.SetActive(false);
    }
}
