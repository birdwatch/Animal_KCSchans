using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharaCtrlL : MonoBehaviour
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
    private float limitLength = 300f;

    void Start()
    {
        m_camera = parameters.GetCamera();
        joycon = parameters.GetJoycon();
    }

    void Update()
    {
        stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        
        MoveCtrl();
        AttackCtrl();
    }

    private void MoveCtrl()
    {
        Vector2 displacement = new Vector2(-joycon.GetStick()[1], joycon.GetStick()[0]);
        Vector3 cameraForward = Vector3.Scale(m_camera.transform.forward, new Vector3(1, 0, 1)).normalized;

        if (displacement.magnitude == 0)
        {
            animator.SetBool("is_running", false);
            animator.SetBool("is_escape", false);
            return;
        }

        animator.SetBool("is_running", true);
        animator.SetBool("is_escape", false);

        if (joycon.GetButton(Joycon.Button.DPAD_RIGHT)) animator.SetBool("is_escape", true);

        float angle = Mathf.Atan(displacement.y / displacement.x);

        if (displacement.x > 0) angle = (-angle + Mathf.PI / 2.0f) / Mathf.PI * 180f + m_camera.transform.localEulerAngles.y;
        else angle = (Mathf.PI + (-angle + Mathf.PI / 2.0f)) / Mathf.PI * 180f + m_camera.transform.localEulerAngles.y;
        
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        Vector3 v = new Vector3();

        if (stateInfo.IsName("Base Layer.Go_foward") || stateInfo.IsName("Base Layer.Hover"))
        {
            v = (cameraForward * displacement.y + m_camera.transform.right * displacement.x) * speed;

            if ((joycon.GetButton(Joycon.Button.DPAD_DOWN)) || (joycon.GetButton(Joycon.Button.DPAD_LEFT)))
            {
                v *= 0.6f;
            }
            
        }
        else if (stateInfo.IsName("Base Layer.Escape"))
        {
            v = (cameraForward * displacement.y + m_camera.transform.right * displacement.x) * speed * 2f;
        }
        else if (stateInfo.IsName("Base Layer.Langing"))
        {
            v = (cameraForward * displacement.y + m_camera.transform.right * displacement.x) * speed * 0.7f;
        }

        if (transform.position.x >= limitLength && v.x > 0) v.x = 0f;
        if (transform.position.x <= -limitLength && v.x < 0) v.x = 0f;
        if (transform.position.z >= limitLength && v.z > 0) v.z = 0f;
        if (transform.position.z <= -limitLength && v.z < 0) v.z = 0f;

        transform.position += v;
        m_camera.transform.position += v;
    }

    private void AttackCtrl()
    {
        if (joycon.GetButton(Joycon.Button.DPAD_DOWN)) animator.SetInteger("is_swing", 1);
        else if (joycon.GetButton(Joycon.Button.DPAD_LEFT)) animator.SetInteger("is_swing", 2);
        else animator.SetInteger("is_swing", 0);
    }
}
