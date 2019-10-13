using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBarCtrl : MonoBehaviour
{
    private float nowHP;
    private float MaxHP;
    private bool isVibrate = false;
    private float t = 0;

    private Vector3 m_pos;
        
    [SerializeField]
    private Slider HPBar = null;

    // Start is called before the first frame update
    void Start()
    {
        m_pos = this.gameObject.GetComponent<RectTransform>().localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        HPBar.maxValue = MaxHP;
        HPBar.value = nowHP;
        if (isVibrate) Vibrate();
        t += Time.deltaTime;
    }

    public void SetHP(int hp)
    {
        MaxHP = hp;
        nowHP = hp;
    }

    public void UpdateHP(float Num)
    {
        if(nowHP != Num)
        {
            t = 0f;
            isVibrate = true;
        }
        nowHP = Num;
    }

    private void Vibrate()
    {
        //-velocity ~ velocity の乱数
        int value1 = Random.Range(-2, 2);
        int value2 = Random.Range(-2, 2);
        
        // value1, value2 の分だけ移動させる
        Vector3 d_pos = m_pos;
        d_pos.x += value1;
        d_pos.y += value2;
        this.gameObject.GetComponent<RectTransform>().localPosition = d_pos;
        if (t >= 0.2f) isVibrate = false;
    }
}
