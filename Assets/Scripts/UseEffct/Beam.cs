using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    [SerializeField]
    private GameObject beam;

    [SerializeField]
    private Parameters parameters;

    private int count = 15;
    private int layer;
    private List<GameObject> beams;
    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.layer == 10) // Player1
        {
            layer = 8; // Magic1
        }
        else if (this.gameObject.layer == 11) // Player2
        {
            layer = 9; // Magic2
        }
        else
        {
            Debug.Log("Error");
        }

        target = parameters.GetTarget();
        beams = new List<GameObject>();
        PoolBeams();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void PoolBeams()
    {
        for (int i = 0; i < count; i++)
        {
            GameObject obj = Instantiate<GameObject>(beam);
            beams.Add(obj);
            obj.layer = layer;
            obj.SetActive(false);
        }
    }

    private GameObject GetObject()
    {
        // 使用中でないものを探して返す
        foreach (GameObject obj in beams)
        {
            if (obj.activeSelf == false)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        // 全て使用中だったら新しく作って返す
        GameObject newObj = Instantiate(beam);
        newObj.SetActive(true);
        beams.Add(newObj);

        return newObj;
    }

    public void FireBeam()
    {
        GameObject b = GetObject();
        b.transform.position = transform.position;
        b.transform.GetChild(1).GetComponent<BeamCtrl>().Play(target);
    }
}
