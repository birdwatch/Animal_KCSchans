using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPCtrl : MonoBehaviour
{
    [SerializeField]
    private Parameters parameters;

    private Parameters e_parameters;

    private HPBarCtrl hpbCtrl;
    private HPBarCtrl e_hpbCtrl;

    // Start is called before the first frame update
    void Start()
    {
        hpbCtrl = parameters.GetCanvas().gameObject.transform.GetChild(1).GetComponent<HPBarCtrl>();
        hpbCtrl.SetHP(parameters.GetHP());

        e_parameters = parameters.GetTarget().GetComponent<Parameters>();
        e_hpbCtrl = parameters.GetCanvas().gameObject.transform.GetChild(2).GetComponent<HPBarCtrl>();
        e_hpbCtrl.SetHP(e_parameters.GetHP());
    }

    // Update is called once per frame
    void Update()
    {
        hpbCtrl.UpdateHP(parameters.GetnowHP());
        e_hpbCtrl.UpdateHP(e_parameters.GetnowHP());
    }
}
