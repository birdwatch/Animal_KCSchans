using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoChara : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> list;

    [SerializeField]
    private Selecter selecter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0; i<3; i++)
        {
            if(i == selecter.selected)
            {
                list[i].SetActive(true);
            }
            else
            {
                list[i].SetActive(false);
            }
        }
    }
}
