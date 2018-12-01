using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour {

    public GameObject loadingBarAsset;
	public void LoadScene(int num)
    {
        StartCoroutine(LoadingBar(SceneManager.LoadSceneAsync(num)));
    }
    IEnumerator LoadingBar(AsyncOperation operation)
    {
        GameObject loadingBar = (GameObject)Instantiate(loadingBarAsset);
        Slider slider = loadingBar.GetComponentInChildren<Slider>();
        Text percentage = loadingBar.GetComponentInChildren<Text>();
        while (!operation.isDone)
        {
            slider.value = operation.progress;
            percentage.text = "Loading: " + Mathf.RoundToInt(operation.progress * 100) + "%";
            yield return null;
        }
    }
}
