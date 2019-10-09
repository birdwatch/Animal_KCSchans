using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Parameters : MonoBehaviour
{
    [SerializeField]
    private int maxHP;
    private int nowHP;

    private Joycon myJoycon;
    private List<Joycon> m_joycons;
    private Joycon m_joyconL;
    private Joycon m_joyconR;
    private static readonly Joycon.Button[] m_buttons =
        Enum.GetValues(typeof(Joycon.Button)) as Joycon.Button[];

    private Camera m_camera;
    private Camera t_camera;
    private GameObject target;
    private bool isLocked;


    // Start is called before the first frame update
    void Start()
    {
        SetControllers();

        if (gameObject.tag == "Player1")
        {
            myJoycon = m_joyconL;
            target = GameObject.FindGameObjectWithTag("Player2");
            m_camera = GameObject.Find("Camera").GetComponent<Camera>();
            t_camera = GameObject.Find("Camera2").GetComponent<Camera>();
        }
        else if (gameObject.tag == "Player2")
        {
            myJoycon = m_joyconR;
            target = GameObject.FindGameObjectWithTag("Player1");
            m_camera = GameObject.Find("Camera2").GetComponent<Camera>();
            t_camera = GameObject.Find("Camera").GetComponent<Camera>();
            Debug.Log(myJoycon);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnWillRenderObject()
    {
        if (Camera.current.name == t_camera.name) isLocked = true;
        else if (Camera.current.name == m_camera.name) return;
        else isLocked = false;
    }

    private void SetControllers()
    {
        m_joycons = JoyconManager.Instance.j;
        if (m_joycons == null || m_joycons.Count <= 0) return;
        m_joyconL = m_joycons.Find(c => c.isLeft);
        m_joyconR = m_joycons.Find(c => !c.isLeft);
    }

    public GameObject GetTarget(){ return target; }

    public Joycon GetJoycon(){ return myJoycon; }

    public Camera GetCamera(){ return m_camera; }
    public void SetCamera(Camera c) { m_camera = c; }

    public bool GetIsLooked() { return isLocked; }

    public int GetHP() { return maxHP; }
}