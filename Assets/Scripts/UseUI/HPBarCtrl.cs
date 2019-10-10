using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBarCtrl : MonoBehaviour
{
    private float nowHP;
    private float MaxHP;

    [SerializeField]
    private Slider HPBar = null;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        HPBar.maxValue = MaxHP;
        HPBar.value = nowHP;

        if (nowHP <= 0)
        {
            //setCharacter.erace(transform.parent.parent.gameObject);
        }
    }

    public void SetHP(int hp)
    {
        MaxHP = hp;
        nowHP = hp;
    }

    public void UpdateHP(float Num)
    {
        nowHP = Num;
    }
}
