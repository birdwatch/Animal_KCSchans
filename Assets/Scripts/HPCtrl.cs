using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPCtrl : MonoBehaviour
{
    [SerializeField]
    private Parameters parameters;

    private HPBarCtrl hpbCtrl;
    private HPBarCtrl e_hpbCtrl;

    // Start is called before the first frame update
    void Start()
    {
        hpbCtrl = transform.GetChild(1).GetChild(1).GetComponent<HPBarCtrl>();
        hpbCtrl.SetHP(parameters.GetHP());

        e_hpbCtrl = transform.GetChild(1).GetChild(2).GetComponent<HPBarCtrl>();
        e_hpbCtrl.SetHP(parameters.GetTarget().GetComponent<Parameters>().GetHP());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
