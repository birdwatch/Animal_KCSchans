using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    private Parameters parameters;
    private GameObject player;
    private GameObject target;
    private GameManeger gameManeger;
    private bool isTarget=false;
    private int userNum = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        target = null ?? parameters.GetTarget();

        if (gameManeger.GetIsPaused()) return;
        
        if (Joycon.GetButtonDown(userNum, Joycon.Button.CAPTURE)) isTarget = !isTarget;

        if (isTarget || ((Joycon.GetButton(userNum, Joycon.Button.SL)) && (Joycon.GetButton(userNum, Joycon.Button.SR))))
        {
            transform.RotateAround(player.transform.position, Vector3.up, 
                Vector3.Cross((- this.transform.position + player.transform.position).normalized,
                (target.transform.position - player.transform.position)).normalized.y * 7f);
        }
        else if(Joycon.GetButton(userNum, Joycon.Button.SL))
        {
            transform.RotateAround(player.transform.position, Vector3.up, -5f);
        }
        else if (Joycon.GetButton(userNum, Joycon.Button.SR))
        {
            transform.RotateAround(player.transform.position, Vector3.up, 5f);
        }
    }

    public void SetUser(int i) { userNum = i; }

    public void SetChara(GameObject o) { player = o; }

    public void SetParameters(Parameters p) { parameters = p; }

    public void SetGameManeger(GameManeger gm) { gameManeger = gm; }
}
