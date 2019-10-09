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

    private Camera m_camera;
    private Joycon joycon;
    private AnimatorStateInfo stateInfo;

    void Start()
    {
        m_camera = parameters.GetCamera();
        joycon = parameters.GetJoycon();
    }

    void Update()
    {
        stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        MoveCtrl();
        attackCtrl();
    }

    private void MoveCtrl()
    {
        Vector2 displacement = new Vector2(joycon.GetStick()[1], -joycon.GetStick()[0]);
        Vector3 cameraForward = Vector3.Scale(m_camera.transform.forward, new Vector3(1, 0, 1)).normalized;

        if (displacement.magnitude == 0)
        {
            animator.SetBool("is_running", false);
            animator.SetBool("is_escape", false);
            return;
        }

        animator.SetBool("is_running", true);
        animator.SetBool("is_escape", false);

        float angle = Mathf.Atan(displacement.y / displacement.x);

        if (displacement.x > 0) angle = -angle + Mathf.PI / 2.0f;
        else angle = Mathf.PI + (-angle + Mathf.PI / 2.0f);

        angle = angle / Mathf.PI * 180f;

        if (angle == 180f) angle = 0f;
        if (angle == 360f) angle = 180f;

        angle += m_camera.transform.localEulerAngles.y;

        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        if (stateInfo.IsName("Base Layer.Go_foward") || stateInfo.IsName("Base Layer.Hover"))
        {
            if ((joycon.GetButton(Joycon.Button.DPAD_DOWN)) || (joycon.GetButton(Joycon.Button.DPAD_LEFT)))
            {
                transform.position += (cameraForward * displacement.y + m_camera.transform.right * displacement.x) * speed * 0.6f;
                m_camera.transform.position += (cameraForward * displacement.y + m_camera.transform.right * displacement.x) * speed * 0.6f;
            }
            else
            {
                transform.position += (cameraForward * displacement.y + m_camera.transform.right * displacement.x) * speed;
                m_camera.transform.position += (cameraForward * displacement.y + m_camera.transform.right * displacement.x) * speed;
            }

        }
        else if (stateInfo.IsName("Base Layer.Escape"))
        {
            transform.position += (cameraForward * displacement.y + m_camera.transform.right * displacement.x) * speed * 2f;
            m_camera.transform.position += (cameraForward * displacement.y + m_camera.transform.right * displacement.x) * speed * 2f;
        }
        else if (stateInfo.IsName("Base Layer.Langing"))
        {
            transform.position += (cameraForward * displacement.y + m_camera.transform.right * displacement.x) * speed * 0.7f;
            m_camera.transform.position += (cameraForward * displacement.y + m_camera.transform.right * displacement.x) * speed * 0.7f;
        }

    }

    private void attackCtrl()
    {
        if (joycon.GetButton(Joycon.Button.DPAD_DOWN)) animator.SetInteger("is_swing", 1);
        else if (joycon.GetButton(Joycon.Button.DPAD_LEFT)) animator.SetInteger("is_swing", 2);
        else animator.SetInteger("is_swing", 0);
    }
}
