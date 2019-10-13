using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Joycon : MonoBehaviour
{
    private bool isShow = false;
    private static int keyUser = 0;
    private static int joyconNum = 0;

    private static Controller player1 = Controller.JoyCon_L;
    private static Controller player2 = Controller.JoyCon_R;

    private List<Joycon2> m_joycons;
    private static Joycon2 m_joyconL;
    private static Joycon2 m_joyconR;

    static Joycon instance;

    private static readonly Button[] m_button = Enum.GetValues(typeof(Button)) as Button[];

    public static Joycon Instance { get { return instance; }}

    public enum Button : int
    {
        NULL = -1,
        ATTACK_S = 0,
        ATTACK_W = 1,
        JUMP = 2,
        ESCAPE = 3,
        SL = 4,
        SR = 5,
        MINUS = 8,
        PLUS = 9,
        STICK_L = 10,
        STICK_R = 11,
        HOME = 12,
        CAPTURE = 13,
        SHOULDER_1 = 14,
        SHOULDER_2 = 15,

        TARGET = HOME | CAPTURE,
        SPECIAL = PLUS | MINUS,
        STICK = STICK_L | STICK_R
    };

    public enum Controller : int
    {
        KeyBord = 0,
        JoyCon_L = 1,
        JoyCon_R = 2
    }

    private static readonly Dictionary<Button ,KeyCode> Button2Key = new Dictionary<Button, KeyCode>()
    {
        {Button.ATTACK_S, KeyCode.Mouse0},
        {Button.ATTACK_W, KeyCode.Mouse1},
        {Button.JUMP,     KeyCode.Space},
        {Button.ESCAPE,   KeyCode.E},
        {Button.SL,       KeyCode.LeftArrow},
        {Button.SR,       KeyCode.RightArrow},
        {Button.SPECIAL,  KeyCode.Q},
        {Button.TARGET,   KeyCode.C},
        {Button.STICK,    KeyCode.R},
        {Button.SHOULDER_1, KeyCode.Alpha1},
        {Button.SHOULDER_2, KeyCode.Alpha2}
    };

    private static readonly Dictionary<Button, Joycon2.Button> Button2Button_L = new Dictionary<Button, Joycon2.Button>()
    {
        {Button.ATTACK_W , Joycon2.Button.DPAD_DOWN},
        {Button.ATTACK_S, Joycon2.Button.DPAD_LEFT},
        {Button.JUMP, Joycon2.Button.DPAD_UP},
        {Button.ESCAPE, Joycon2.Button.DPAD_RIGHT},
        {Button.SL, Joycon2.Button.SL},
        {Button.SR, Joycon2.Button.SR},
        {Button.SPECIAL, Joycon2.Button.MINUS},
        {Button.TARGET, Joycon2.Button.CAPTURE},
        {Button.STICK, Joycon2.Button.STICK},
        {Button.SHOULDER_1, Joycon2.Button.SHOULDER_1},
        {Button.SHOULDER_2, Joycon2.Button.SHOULDER_2}
    };

    private static readonly Dictionary<Button, Joycon2.Button> Button2Button_R = new Dictionary<Button, Joycon2.Button>()
    {
        {Button.ATTACK_W , Joycon2.Button.DPAD_UP},
        {Button.ATTACK_S, Joycon2.Button.DPAD_RIGHT},
        {Button.JUMP, Joycon2.Button.DPAD_DOWN},
        {Button.ESCAPE, Joycon2.Button.DPAD_LEFT},
        {Button.SL, Joycon2.Button.SL},
        {Button.SR, Joycon2.Button.SR},
        {Button.SPECIAL, Joycon2.Button.MINUS},
        {Button.TARGET, Joycon2.Button.HOME},
        {Button.STICK, Joycon2.Button.STICK},
        {Button.SHOULDER_1, Joycon2.Button.SHOULDER_1},
        {Button.SHOULDER_2, Joycon2.Button.SHOULDER_2}
    };

    void Awake()
    {
        if (instance != null) Destroy(gameObject);
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        m_joycons = JoyconManager.Instance.j;

        if (m_joycons == null || m_joycons.Count <= 0) return;

        m_joyconL = m_joycons.Find(c => c.isLeft);
        m_joyconR = m_joycons.Find(c => !c.isLeft);
    }

    void Update()
    {
        joyconNum = Input.GetJoystickNames().Length;
        if (Input.GetKeyDown(KeyCode.J) && Input.GetKey(KeyCode.LeftControl)) isShow = !isShow;
    }

    public static bool GetButton(int playerNum, Button b)
    {
        Controller c = (playerNum == 1) ? player1 : player2;

        switch((int) c)
        {
            case 0:
                return Input.GetKey(Button2Key[b]);

            case 1:
                return (m_joyconL.GetButton(Button2Button_L[b]));

            case 2:
                return (m_joyconR.GetButton(Button2Button_R[b]));

            default:
                Debug.Log("Error: GetButton" + c + b);
                return false;
        }
    }

    public static bool GetButtonDown(int playerNum, Button b)
    {
        Controller c = (playerNum == 1) ? player1 : player2;

        switch ((int)c)
        {
            case 0:
                return Input.GetKeyDown(Button2Key[b]);

            case 1:
                return (m_joyconL.GetButtonDown(Button2Button_L[b]));

            case 2:
                return (m_joyconR.GetButtonDown(Button2Button_R[b]));

            default:
                Debug.Log("Error: GetButton" + c + b);
                return false;
        }
    }

    public static bool GetButtonUp(int playerNum, Button b)
    {
        Controller c = (playerNum == 1) ? player1 : player2;

        switch ((int)c)
        {
            case 0:
                return Input.GetKeyUp(Button2Key[b]);

            case 1:
                return (m_joyconL.GetButtonUp(Button2Button_L[b]));

            case 2:
                return (m_joyconR.GetButtonUp(Button2Button_R[b]));

            default:
                Debug.Log("Error: GetButton" + c + b);
                return false;
        }
    }
    
    public static float[] GetAxis(int playerNum)
    {
        float[] axis = { 0, 0 };
        
        float v = 0;
        float h = 0;

        Controller c = (playerNum == 1) ? player1 : player2;

        switch ((int)c)
        {
            case 0:
                if (Input.GetKey(KeyCode.A)) h -= 1f;
                if (Input.GetKey(KeyCode.D)) h += 1f;
                if (Input.GetKey(KeyCode.W)) v += 1f;
                if (Input.GetKey(KeyCode.S)) v -= 1f;
                
                break;

            case 1:
                v = m_joyconL.GetStick()[0];
                h = - m_joyconL.GetStick()[1];

                break;

            case 2:
                v = - m_joyconR.GetStick()[0];
                h = m_joyconR.GetStick()[1];
                break;

            default:
                Debug.Log("Error: GetAxis");
                break;
        }
        
        axis[0] = h;
        axis[1] = v;

        return axis;
    }

    public static Button AnyButton(int num)
    {
        var convert = Button2Button_L;
        Button b = Button.NULL;
        foreach(var b2b in convert)
        {
            b = GetButton(num, b2b.Key) ? b2b.Key : b;
        }

        return b;
    }

    public static void SetPlayer(string playerTag, Controller c)
    {
        if (playerTag == "Player1") player1 = c;
        else player2 = c;
    }

    private void OnGUI()
    {
        if (!isShow) return;

        var style = GUI.skin.GetStyle("label");
        style.fontSize = 24;


        GUILayout.BeginHorizontal(GUILayout.Width(960));

        Controller name1 = player1;
        Button button1 = AnyButton(1);
        var stick1 = GetAxis(1);

        GUILayout.BeginVertical(GUILayout.Width(480));
        GUILayout.Label(name1.ToString());
        GUILayout.Label("押されているボタン：" + button1);
        GUILayout.Label(string.Format("スティック：({0}, {1})", stick1[0], stick1[1]));
        GUILayout.EndVertical();

        var name2 = player2;
        Button button2 = AnyButton(2);
        var stick2 = GetAxis(2);

        GUILayout.BeginVertical(GUILayout.Width(480));
        GUILayout.Label(name2.ToString());
        GUILayout.Label("押されているボタン：" + button2);
        GUILayout.Label(string.Format("スティック：({0}, {1})", stick2[0], stick2[1]));
        GUILayout.EndVertical();

        GUILayout.EndHorizontal();
    }
}
