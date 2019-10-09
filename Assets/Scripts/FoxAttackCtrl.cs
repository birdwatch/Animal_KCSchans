using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FoxAttackCtrl : MonoBehaviour
{
    [SerializeField]
    private Parameters parameters;

    [SerializeField]
    private MagicCtrl mc;

    [SerializeField]
    private FireCtrl fc;

    [SerializeField]
    private Animator animator;
    
    private BeamCtrl bc;

    private AnimatorStateInfo stateInfo;
    private float timeOut= 1f;
    private float timeElapsed = 0f;
    private Joycon joycon;

    // Start is called before the first frame update
    void Start()
    {
        bc = GameObject.Find("Beam").GetComponent<BeamCtrl>();
        bc.SetTarget(parameters.GetTarget());
        joycon = parameters.GetJoycon();
    }

    // Update is called once per frame
    void Update()
    {
        stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.IsName("Base Layer.Go_foward") 
            && ((joycon.GetButton(Joycon.Button.DPAD_DOWN)) || (joycon.GetButton(Joycon.Button.DPAD_LEFT))))
        {
            mc.Play();
            Fire();
        }
        else if (stateInfo.IsName("Base Layer.Swing_medium"))
        {
            mc.Play();
            Fire();
        }
        else if (stateInfo.IsName("Base Layer.Swing_strong"))
        {
            bc.Play(transform.position);
        }


        if ((joycon.GetButtonUp(Joycon.Button.DPAD_DOWN) && !joycon.GetButton(Joycon.Button.DPAD_LEFT))
            || (!joycon.GetButton(Joycon.Button.DPAD_DOWN) && joycon.GetButtonUp(Joycon.Button.DPAD_LEFT))
            || (!joycon.GetButton(Joycon.Button.DPAD_DOWN) && !joycon.GetButton(Joycon.Button.DPAD_LEFT)))
        {
            mc.Quit();
        }
    }

    private void Fire()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= timeOut)
        {
            fc.FireBullet();
            timeElapsed = 0.0f;
        }
    }

}
