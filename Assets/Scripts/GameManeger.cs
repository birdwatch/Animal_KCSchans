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
    private int t = 0;

    // Start is called before the first frame update
    void Start()
    {
        text1.enabled = false;
        text2.enabled = false;

        Debug.Log("displays connected: " + Display.displays.Length);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Menu.gameObject.active = !Menu.gameObject.active;

        PauseCtrl();

        if (t == 0 && isEnd && 
            ((Input.GetKeyDown(KeyCode.Z)) || (Joycon.GetButton(1, Joycon.Button.SHOULDER_1) && Joycon.GetButton(2, Joycon.Button.SHOULDER_1)))
            )
        {

            BackTitle();
            t++;
        }
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

    private void BackTitle() { SceneManager.LoadScene("Title"); }

    public bool GetIsPaused() { return isPaused; }
}
