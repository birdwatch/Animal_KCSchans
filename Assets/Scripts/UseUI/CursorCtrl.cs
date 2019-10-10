using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorCtrl : MonoBehaviour
{
    [SerializeField]
    private Parameters parameters;

    [SerializeField]
    private float range;
    
    private RectTransform cursorRt;
    private Image image;
    private bool isLock = false;

    void Start()
    {
        cursorRt = parameters.GetCanvas().transform.GetChild(0).GetComponent<RectTransform>();
        image = parameters.GetCanvas().transform.GetChild(0).GetComponent<Image>();
    }

    void Update()
    {
        if (parameters.GetIsLooked())
        {
            image.enabled = true;
            image.color = new Color(1f, 0f, 0f, 1f);
            cursorRt.position
            = RectTransformUtility.WorldToScreenPoint(parameters.GetCamera(), parameters.GetTarget().transform.position + new Vector3(0f, 3f, 0f));

            Vector2 screenPoint;
            screenPoint.x = cursorRt.position.x - (Screen.width / 2);
            screenPoint.y = cursorRt.position.y - (Screen.height / 2);

            //ロックオンサークル内の場合
            if (screenPoint.magnitude <= range)
            {
                //Debug.Log("aaa");
            }
        }
        else
        {
            image.enabled = false;
        }
    }
}
