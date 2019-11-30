using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBreath : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem breath = null;

    private GameObject obj;
    private string tag;

    private void Start()
    {
        if (breath.loop && breath.isPlaying) breath.loop = false;

        if (this.transform.root.gameObject.layer == 10) // Player1
        {
            this.gameObject.layer = 8; // Magic1
        }
        else if (this.transform.root.gameObject.layer == 11) // Player2
        {
            this.gameObject.layer = 9; // Magic2
        }
        else
        {
            Debug.Log("Error");
        }
    }

    public void Play()
    {
        if (breath.isPlaying) return;
        breath.Play();
        breath.loop = true;
    }

    public void Quit()
    {
        if(breath.loop && breath.isPlaying)breath.loop = false;
    }

    void OnParticleCollision(GameObject o)
    {
        Debug.Log("hit");
        if (o.tag == "Player2" && this.gameObject.transform.root.gameObject.tag != o.tag)
        {
            obj = o;
            o.GetComponent<CharaCtrlR>().enabled = false;
            CancelInvoke("Release2");
            Invoke("Release2", 1f);
            o.gameObject.GetComponent<Parameters>().Freezed();
        }

        if (o.tag == "Player1" && this.gameObject.transform.root.gameObject.tag != o.tag)
        {
            obj = o;
            o.GetComponent<CharaCtrlL>().enabled = false;
            CancelInvoke("Release1");
            Invoke("Release1", 1f);
            o.gameObject.GetComponent<Parameters>().Freezed();
        }
    }

    void Release1()
    {
        obj.GetComponent<CharaCtrlL>().enabled = true;
    }

    void Release2()
    {
        obj.GetComponent<CharaCtrlR>().enabled = true;
    }
}
