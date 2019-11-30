using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonAttackCtrl : MonoBehaviour
{
    [SerializeField]
    private Parameters parameters;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private IceBreath iceBreath;

    [SerializeField]
    private Breath breath;

    private int userNum = 0;

    private AnimatorStateInfo stateInfo;
    private Vector3 p_rotate=new Vector3();
    private Vector3 n_rotate=new Vector3();

    private float t = 0f;
    private float otime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.layer == 10) userNum = 1;
        if (this.gameObject.layer == 11) userNum = 2;

        t += Time.time;
        otime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        n_rotate = Quaternion.ToEulerAngles(this.gameObject.transform.root.rotation);

        t += Time.time - otime;

        if (stateInfo.IsName("Base Layer.Swing_medium") && t < 10f)
        {
            iceBreath.Play();
            breath.Quit();
            if (n_rotate.y - p_rotate.y >= 1.2)
            {
                //this.gameObject.transform.root.rotation = Quaternion.Euler(p_rotate + new Vector3(0, 1.2f, 0));
            }

            if (n_rotate.y - p_rotate.y <= -1.2)
            {
                //this.gameObject.transform.root.rotation = Quaternion.Euler(p_rotate + new Vector3(0, -1.2f, 0));
            }
        }
        else if (stateInfo.IsName("Base Layer.Swing_medium")
            && t < 18f)
        {
            iceBreath.Quit();
            breath.Quit();
        }
        else if (stateInfo.IsName("Base Layer.Swing_strong") && t < 10f)
        {
            iceBreath.Quit();
            breath.Play();
            if (n_rotate.y - p_rotate.y >= 0.7)
            {
                //this.gameObject.transform.root.rotation = Quaternion.Euler(p_rotate + new Vector3(0, 0.7f, 0));
            }

            if (n_rotate.y - p_rotate.y <= -0.7)
            {
                //this.gameObject.transform.root.rotation = Quaternion.Euler(p_rotate + new Vector3(0, -0.7f, 0));
            }
        }
        else if (stateInfo.IsName("Base Layer.Swing_strong")
            && t < 18f)
        {
            iceBreath.Quit();
            breath.Quit();
        }
        else if (stateInfo.IsName("Base Layer.Go_foward")
            && (Joycon.GetButton(userNum, Joycon.Button.ATTACK_S))
            && t < 8f)
        {
            iceBreath.Quit();
            breath.Play();
        }
        else if (stateInfo.IsName("Base Layer.Go_foward")
            && (Joycon.GetButton(userNum, Joycon.Button.ATTACK_S))
            && t < 18f)
        {
            iceBreath.Quit();
            breath.Quit();
        }
        else
        {
            t = 0f;
            iceBreath.Quit();
            breath.Quit();
            p_rotate = Quaternion.ToEulerAngles(this.gameObject.transform.root.rotation);
        }

        otime = Time.time;
    }
}
