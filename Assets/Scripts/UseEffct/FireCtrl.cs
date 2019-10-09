using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private Parameters parameters;

    private int count = 15;
    private List<GameObject> bullets;
    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        target = parameters.GetTarget();
        bullets = new List<GameObject>();
        PoolBullets();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void PoolBullets()
    {
        for(int i=0; i < count; i++)
        {
            GameObject obj = Instantiate<GameObject>(bullet);
            obj.GetComponent<Bullet>().SetTarget(target.tag);
            bullets.Add(obj);
            obj.SetActive(false);
        }
    }

    private GameObject GetObject()
    {
        // 使用中でないものを探して返す
        foreach (GameObject obj in bullets)
        {
            if (obj.activeSelf == false)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        // 全て使用中だったら新しく作って返す
        GameObject newObj = Instantiate(bullet);
        newObj.GetComponent<Bullet>().SetTarget(target.tag);
        newObj.SetActive(true);
        bullets.Add(newObj);

        return newObj;
    }

    public void FireBullet()
    {
        GameObject b = GetObject();
        b.transform.position = transform.position;
        b.GetComponent<Bullet>().Fire(this.gameObject, target);
    }
}
