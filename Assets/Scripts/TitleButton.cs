using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{
    [SerializeField]
    private RectTransform rt;

    [SerializeField]
    private LoadingScene ls;

    [SerializeField]
    private Canvas canvas;

    private float delta = 0.2f;
    private float t = 0;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        Resources.UnloadUnusedAssets();

        Debug.Log("displays connected: " + Display.displays.Length);
        // Display.displays[0] は主要デフォルトディスプレイで、常に ON。
        // 追加ディスプレイが可能かを確認し、それぞれをアクティベートします。
        if (Display.displays.Length > 1)
            Display.displays[1].Activate();
        if (Display.displays.Length > 2)
            Display.displays[2].Activate();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space))) onClick();

        ChangeScale();

        t += Time.deltaTime;
    }

    public void onClick()
    {
        canvas.gameObject.SetActive(true);
        ls.LoadNextScene();
    }

    private void ChangeScale()
    {
        rt.localScale = new Vector3(1f + delta * Mathf.Cos(t * 2f), 1f + delta * Mathf.Cos(t * 2f), 1f);
    }
}
