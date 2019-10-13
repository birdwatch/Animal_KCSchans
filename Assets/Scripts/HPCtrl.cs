using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPCtrl : MonoBehaviour
{
    [SerializeField]
    private Parameters parameters;
    private Parameters t_parameters;

    private HPBarCtrl hpbCtrl;
    private HPBarCtrl t_hpbCtrl;

    // Start is called before the first frame update
    void Start()
    {
        hpbCtrl = parameters.GetCanvas().gameObject.transform.GetChild(1).GetComponent<HPBarCtrl>();
        hpbCtrl.SetHP(parameters.GetHP());

        t_parameters = parameters.GetTarget().GetComponent<Parameters>();
        t_hpbCtrl = parameters.GetCanvas().gameObject.transform.GetChild(4).GetComponent<HPBarCtrl>();
        t_hpbCtrl.SetHP(t_parameters.GetHP());
    }

    // Update is called once per frame
    void Update()
    {
        hpbCtrl.UpdateHP(parameters.GetnowHP());
        t_hpbCtrl.UpdateHP(t_parameters.GetnowHP());
        if (parameters.GetnowHP() <= 0)
        {
            GameObject.Find("SetPlayer").GetComponent<GameManeger>().GetWinner(this.gameObject);
        }
    }
}
