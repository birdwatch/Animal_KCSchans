using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    private Parameters parameters;
    private Joycon joycon;
    private GameObject player;
    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        joycon = null ?? parameters.GetJoycon();
        target = null ?? parameters.GetTarget();

        if ((joycon.GetButton(Joycon.Button.SL)) && (joycon.GetButton(Joycon.Button.SR)))
        {
            transform.RotateAround(player.transform.position, Vector3.up, 
                Vector3.Cross((- this.transform.position + player.transform.position).normalized,
                (target.transform.position - player.transform.position)).normalized.y * 7f);
        }
        else if(joycon.GetButton(Joycon.Button.SL))
        {
            transform.RotateAround(player.transform.position, Vector3.up, -5f);
        }
        else if (joycon.GetButton(Joycon.Button.SR))
        {
            transform.RotateAround(player.transform.position, Vector3.up, 5f);
        }
    }

    public void SetChara(GameObject o) { player = o; }

    public void SetParameters(Parameters p) { parameters = p; }
}
