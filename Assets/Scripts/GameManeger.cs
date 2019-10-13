using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManeger : MonoBehaviour
{
    [SerializeField]
    private Text text1;

    [SerializeField]
    private Text text2;

    [SerializeField]
    private Canvas Menu;

    private bool isPaused = false;
    private bool isEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        text1.enabled = false;
        text2.enabled = false;

        Debug.Log("displays connected: " + Display.displays.Length);
        // Display.displays[0] は主要デフォルトディスプレイで、常に ON。
        // 追加ディスプレイが可能かを確認し、それぞれをアクティベートします。
        if (Display.displays.Length > 1)
            Display.displays[1].Activate();
        if (Display.displays.Length > 2)
            Display.displays[2].Activate();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Menu.gameObject.active = !Menu.gameObject.active;

        PauseCtrl();

        if(isEnd && ((Input.GetKeyDown(KeyCode.Z)) || (Joycon.GetButton(1,Joycon.Button.SHOULDER_1) && Joycon.GetButton(2,Joycon.Button.SHOULDER_1)))) BackTitle();
    }

    public void GetWinner(GameObject loser)
    {
        if(loser.tag == "Player1")
        {
            text1.enabled = true;
            text1.text = "YOU LOSE";
            text1.color = new Color(0f, 0f, 1f, 1f);

            text2.enabled = true;
            text2.text = "YOU WIN";
            text2.color = new Color(1f, 0f, 0f, 1f);
        }
        if(loser.tag == "Player2")
        {
            text2.enabled = true;
            text2.text = "YOU LOSE";
            text2.color = new Color(0f, 0f, 1f, 1f);

            text1.enabled = true;
            text1.text = "YOU WIN";
            text1.color = new Color(1f, 0f, 0f, 1f);
        }
        Invoke("a", 0.2f);
    }

    public void PauseCtrl()
    {
        if (Menu.isActiveAndEnabled || isEnd)
        {
           isPaused = true;
            Time.timeScale = 0f;
        }
        else
        {
            isPaused = false;
            Time.timeScale = 1f;
        }
    }
    
    private void a() { isEnd = true; }

    private void BackTitle() { SceneManager.LoadScene("title"); }

    public bool GetIsPaused() { return isPaused; }
}
