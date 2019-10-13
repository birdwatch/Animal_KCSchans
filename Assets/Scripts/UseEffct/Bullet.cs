using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private bool isPlayed = false;
    private float t = 0f;
    private float distance = 0;
    private float speed = 20.0f;
    private Vector3 initPos;
    private Vector3 targetPos;
    private Vector3 relayPos;

    private BurstCtrl bc;
    private string targetTag;
    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        bc = GameObject.FindGameObjectWithTag("Fire").GetComponent<BurstCtrl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayed)
        {
            // 現在の位置
            float nowLocation = (t * speed) / distance;

            if (nowLocation >= 0.99999f)
            {
                bc.Play(transform.position);
                isPlayed = false;
                this.gameObject.SetActive(false);
            }
            else if (nowLocation >= 0.3f) t += Time.deltaTime * 7f;
            else if (nowLocation >= 0.25f) t += Time.deltaTime * 0.1f;

            // オブジェクトの移動
            transform.position = Vector3.Lerp(Vector3.Lerp(initPos, relayPos, t)
            , Vector3.Lerp(relayPos, target.transform.position, t)
            , nowLocation);
            t += Time.deltaTime;
        }
        
    }

    public void Fire(GameObject from, GameObject to)
    {
        Invoke("a", 0.5f);
        initPos = from.transform.position;
        target = to.gameObject;
        targetPos = to.transform.position;
        if (Vector3.Magnitude(initPos - targetPos) <= 10f) targetPos = initPos + new Vector3(0.1f, 0f, 0f);
        if (Vector3.Magnitude(initPos - targetPos) >= 250f) targetPos = initPos + new Vector3(0.1f, 0f, 0f);
        t = 0f;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == targetTag)
        {
            Debug.Log("damage");
            collider.gameObject.GetComponent<Parameters>().Damaged(10);
            bc.Play(transform.position);
            isPlayed = false;
            this.gameObject.SetActive(false);
        }
        
    }

    private void a()
    {
        if (!isPlayed)
        {
            isPlayed = true;
            
            distance = Vector3.Distance(initPos, targetPos);
            relayPos = (initPos + 3* targetPos) / 4 + new Vector3(Random.Range(-15.0f, 15.0f), 15.0f, Random.Range(-15.0f, 15.0f));
        }
    }

    public void SetTarget(string tag)
    {
        targetTag = tag;
    }
}
