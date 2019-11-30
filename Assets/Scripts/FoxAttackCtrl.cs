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

    [SerializeField]
    private Beam bc;

    private AnimatorStateInfo stateInfo;
    private float timeOut= 1.5f;
    private float timeElapsed = 0f;
    private bool isAttacking = false;
    private int userNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.layer == 10) userNum = 1;
        if (this.gameObject.layer == 11) userNum = 2;
    }

    // Update is called once per frame
    void Update()
    {
        stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.IsName("Base Layer.Idle"))
        {
            isAttacking = false;
        } 
        if (stateInfo.IsName("Base Layer.Go_foward") 
            && ((Joycon.GetButton(userNum, Joycon.Button.ATTACK_W)) || (Joycon.GetButton(userNum, Joycon.Button.ATTACK_S))))
        {
            mc.Play();
            Fire(1);
        }
        else if (!isAttacking && stateInfo.IsName("Base Layer.Swing_medium"))
        {
            fc.FireBullet();
            Fire(1f);

            isAttacking = true;
        }
        else if (!isAttacking && stateInfo.IsName("Base Layer.Swing_strong"))
        {
            bc.FireBeam();
            mc.Quit();
            isAttacking = true;
        }


        if ((Joycon.GetButtonUp(userNum, Joycon.Button.ATTACK_W) && !Joycon.GetButton(userNum, Joycon.Button.ATTACK_S))
            || (!Joycon.GetButton(userNum, Joycon.Button.ATTACK_W) && Joycon.GetButtonUp(userNum, Joycon.Button.ATTACK_S))
            || (!Joycon.GetButton(userNum, Joycon.Button.ATTACK_W) && !Joycon.GetButton(userNum, Joycon.Button.ATTACK_S)))
        {
            mc.Quit();
        }

        timeElapsed += Time.deltaTime;
    }

    private void Fire(float i)
    {

        if (timeElapsed >= timeOut * i)
        {
            fc.FireBullet();
            timeElapsed = 0.0f;
        }
    }

}
