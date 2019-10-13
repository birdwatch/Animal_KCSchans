using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    [SerializeField]
    private GameObject LoadingUi;

    [SerializeField]
    private  Slider Slider;

    private AsyncOperation async;
    private string sceneName = "Battle";

    public void LoadNextScene()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        async = SceneManager.LoadSceneAsync(sceneName);
        while (!async.isDone)
        {
            Slider.value = async.progress;
            yield return null;
        }
    }

}
