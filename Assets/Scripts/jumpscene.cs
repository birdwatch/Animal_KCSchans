using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class jumpscene : MonoBehaviour
{
    public string scenename;

    public void Start()
    {
        SceneManager.LoadScene(scenename);
    }
}
