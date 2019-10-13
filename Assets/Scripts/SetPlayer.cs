using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject[] kcschans;

    [SerializeField]
    private Vector3[] positions;

    [SerializeField]
    private Camera camera1;

    [SerializeField]
    private Camera camera2;

    [SerializeField]
    private Canvas canvas1;

    [SerializeField]
    private Canvas canvas2;

    [SerializeField]
    private GameManeger gm;

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = Instantiate(kcschans[0], positions[0], Quaternion.Euler(0,0,0));
        obj.tag = "Player1";
        obj.GetComponent<Parameters>().SetCamera(camera1);
        obj.GetComponent<Parameters>().SetCanvas(canvas1);
        obj.GetComponent<CharaCtrlR>().enabled = false;
        obj.GetComponent<CharaCtrlL>().SetGameManeger(gm);
        obj.transform.SetSiblingIndex(4);
        camera1.GetComponent<CameraCtrl>().SetUser(1);
        camera1.GetComponent<CameraCtrl>().SetChara(obj);
        camera1.GetComponent<CameraCtrl>().SetParameters(obj.GetComponent<Parameters>());
        camera1.GetComponent<CameraCtrl>().SetGameManeger(gm);
        camera1.transform.position = new Vector3(-5f, 8.0f, -10.0f);

        obj = Instantiate(kcschans[1], positions[1], Quaternion.Euler(0, 0, 0));
        obj.tag = "Player2";
        obj.GetComponent<CharaCtrlL>().enabled = false;
        obj.GetComponent<CharaCtrlR>().SetGameManeger(gm);
        obj.GetComponent<Parameters>().SetCamera(camera2);
        obj.GetComponent<Parameters>().SetCanvas(canvas2);
        obj.transform.SetSiblingIndex(5);
        camera2.GetComponent<CameraCtrl>().SetUser(2);
        camera2.GetComponent<CameraCtrl>().SetChara(obj);
        camera2.GetComponent<CameraCtrl>().SetParameters(obj.GetComponent<Parameters>());
        camera2.GetComponent<CameraCtrl>().SetGameManeger(gm);
        camera2.transform.position = new Vector3(5f, 8.0f, -10.0f);
    }
}
