using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breath : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem breath = null;

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
        if (breath.loop && breath.isPlaying) breath.loop = false;
    }

    void OnParticleCollision(GameObject obj)
    {
        if (this.gameObject.transform.root.gameObject.tag != obj.tag)
        {
            float dis = Vector3.Distance(obj.transform.position, this.transform.root.position);
            int damage = (int)(dis);
            damage = damage / 25 + 1;   
            obj.GetComponent<Parameters>().Damaged(damage);
            Debug.Log(damage);
        }
    }
}
