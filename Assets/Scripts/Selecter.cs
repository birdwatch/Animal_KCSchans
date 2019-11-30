using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selecter : MonoBehaviour
{
    [SerializeField]
    private int userNum;

    [SerializeField]
    private List<Image> images;

    private int cursol = 0;
    public int selected = 0;
    private float t = 0;
    public int unit = -1;

    private float oTime = 0f;
    

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            if (i == selected)
            {
                images[i].color = Color.red;
            }
            else
            {
                images[i].color = Color.blue;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(unit);
        if (Joycon.GetButton(userNum, Joycon.Button.ATTACK_W))
        {
            unit = selected;
            images[unit].color = Color.green;
        }

        if (unit >= 0) return;

        t += Time.time - oTime;

        if (t > 1.0f) t = 0f;
        else return;

        Vector2 displacement = new Vector2(Joycon.GetAxis(userNum)[0], Joycon.GetAxis(userNum)[1]);

        if (displacement.y > 0.5 && cursol == 0) cursol = -1;
        else if (displacement.y < -0.5 && cursol == 0) cursol = 1;
        else cursol = 0;


        Debug.Log(cursol);

        selected += cursol;
        if (selected < 0) selected += 3;
        selected %= 3;

        for (int i = 0; i < 3; i++)
        {
            if(i == selected)
            {
                images[i].color = Color.red;
            }
            else
            {
                images[i].color = Color.blue;
            }
        }

        if (t > 2.0f) t = 0f;
        oTime = Time.time;
    }
}
