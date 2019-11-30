using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Parameters : MonoBehaviour
{
    [SerializeField]
    private int maxHP;

    [SerializeField]
    private Animator animator;

    private int nowHP;

    private Camera m_camera;
    private Camera t_camera;
    private Canvas canvas;
    private GameObject target;
    private bool isLocked = false;
    private bool isPaused = false;
    
    // Start is called before the first frame update
    void Start()
    {
        nowHP = maxHP;
        if(this.gameObject.tag == "Player1") SetTarget(GameObject.FindGameObjectWithTag("Player2"));
        if(this.gameObject.tag == "Player2") SetTarget(GameObject.FindGameObjectWithTag("Player1"));
    }

    // Update is called once per frame
    void Update()
    {
        if (isLocked && Vector3.Dot(m_camera.transform.forward, target.transform.position - m_camera.transform.position) < 0) isLocked = false;
    }

    void OnWillRenderObject()
    {
        if (Camera.current.name == m_camera.name) isLocked = true;
    }

    public void Damaged(int num)
    {
        if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Escape")) nowHP -= num;
    }

    public void Freezed()
    {
        animator.SetBool("is_freezed", true);
    }

    public GameObject GetTarget(){ return target; }
    public void SetTarget(GameObject o){ target = o; }

    public Camera GetCamera(){ return m_camera; }
    public void SetCamera(Camera c) { m_camera = c; }

    public Canvas GetCanvas() { return canvas; }
    public void SetCanvas(Canvas c) { canvas = c; }

    public bool GetIsLooked() { return isLocked; }

    public int GetHP() { return maxHP; }
    public int GetnowHP() { return nowHP; }
}