using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCtrl : MonoBehaviour
{
    [SerializeField]
    private string sceneName = "";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CloseButtonClicked()
    {
        this.gameObject.SetActive(false);
    }

    public void ExitButtonClicked()
    {
        Resources.UnloadUnusedAssets();
        if(sceneName == "Quit") Application.Quit();
        else SceneManager.LoadScene(sceneName);
    }
}
