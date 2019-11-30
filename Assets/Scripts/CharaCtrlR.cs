using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharaCtrlR : MonoBehaviour
{
    [SerializeField]
    private Parameters parameters;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private float speed;

    private int userNum = 2;
    private Camera m_camera;
    private AnimatorStateInfo stateInfo;
    private float limitLength = 125f;
    private float time = 0;
    private GameManeger gameManeger;
    private float angle = 0f;
    private float t = 0;

    void Start()
    {
        m_camera = parameters.GetCamera();
    }

    void Update()
    {
        animator.SetBool("is_freezed", false);
        stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        
        MoveCtrl();
        attackCtrl();
        if (parameters.GetnowHP() <= 0) animator.SetBool("is_killed", true);

        time += Time.deltaTime;
    }

    private void MoveCtrl()
    {
        if (gameManeger.GetIsPaused()) return;

        Vector2 displacement = new Vector2(Joycon.GetAxis(userNum)[0], Joycon.GetAxis(userNum)[1]);
        Vector3 cameraForward = Vector3.Scale(m_camera.transform.forward, new Vector3(1, 0, 1)).normalized;

        if (displacement.magnitude == 0)
        {
            animator.SetBool("is_running", false);
            animator.SetBool("is_escape", false);
            return;
        }

        animator.SetBool("is_running", true);
        animator.SetBool("is_escape", false);

        if (time >= 2.1f && Joycon.GetButton(userNum, Joycon.Button.ESCAPE))
        {
            animator.SetBool("is_escape", true);
            time = 0f;
        }

        angle = Mathf.Atan(displacement.y / displacement.x);

        if (displacement.x > 0) angle = -angle + Mathf.PI / 2.0f;
        else angle = Mathf.PI + (angle + Mathf.PI / 2.0f);

        angle = angle / Mathf.PI * 180f;

        if (angle > 180f && angle != 360f) angle = 540f - angle;

        angle += m_camera.transform.localEulerAngles.y;

        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        Vector3 v = new Vector3();

        if (stateInfo.IsName("Base Layer.Go_foward") || stateInfo.IsName("Base Layer.Hover"))
        {
            if ((Joycon.GetButton(userNum, Joycon.Button.ATTACK_S)) || (Joycon.GetButton(userNum, Joycon.Button.ATTACK_W)))
            {
                v = (cameraForward * displacement.y + m_camera.transform.right * displacement.x) *speed * 0.6f;
            }
            else
            {
                v = (cameraForward * displacement.y + m_camera.transform.right * displacement.x) * speed;
            }

        }
        else if (stateInfo.IsName("Base Layer.Escape"))
        {
            v = (cameraForward * displacement.y + m_camera.transform.right * displacement.x) * speed * 1.8f;
        }
        else if (stateInfo.IsName("Base Layer.Langing"))
        {
            v = (cameraForward * displacement.y + m_camera.transform.right * displacement.x) * speed * 0.7f;
            transform.position += (cameraForward * displacement.y + m_camera.transform.right * displacement.x) * speed * 0.7f;
            m_camera.transform.position += (cameraForward * displacement.y + m_camera.transform.right * displacement.x) * speed * 0.7f;
        }

        if (transform.position.x >= limitLength && v.x > 0) v.x = 0f;
        if (transform.position.x <= -limitLength && v.x < 0) v.x = 0f;
        if (transform.position.z >= limitLength && v.z > 0) v.z = 0f;
        if (transform.position.z <= -limitLength && v.z < 0) v.z = 0f;

        transform.position += v;
        m_camera.transform.position += v;
    }

    private void attackCtrl()
    {
        if (Joycon.GetButton(userNum, Joycon.Button.ATTACK_W)) animator.SetInteger("is_swing", 1);
        else if (Joycon.GetButton(userNum, Joycon.Button.ATTACK_S)) animator.SetInteger("is_swing", 2);
        else animator.SetInteger("is_swing", 0);
    }

    public void SetGameManeger(GameManeger gm){ gameManeger = gm; }
    
}
