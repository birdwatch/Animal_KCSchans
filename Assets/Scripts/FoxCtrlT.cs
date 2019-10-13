using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxCtrlT : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private float rasian;

    [SerializeField]
    private GameObject Menu;

    private float speed = 0.2f;
    private float t;

    // Start is called before the first frame update
    void Start()
    {
        
        animator.SetBool("is_running", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Menu.SetActive(!Menu.activeSelf);
        //Debug.Log("a");
        animator.SetBool("is_running", true);
        transform.position = new Vector3(Mathf.Cos(speed * t + rasian), 0f, Mathf.Sin(speed * t + rasian)) * 70f;
        transform.rotation = Quaternion.EulerAngles(0, -speed * t + rasian, 0);
        t += Time.deltaTime;
    }
    
}
