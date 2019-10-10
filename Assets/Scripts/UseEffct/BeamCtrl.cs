using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamCtrl : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem beam;

    [SerializeField]
    private ParticleSystem beam2;

    [SerializeField]
    private CircleCtrl cc;

    private GameObject target;

    private bool isPlayed = false;

    public void Play(Vector3 pos)
    {
        if (!isPlayed)
        {
            isPlayed = true;
            transform.position = new Vector3(target.transform.position.x, 0f, target.transform.position.z);
            Invoke("Fire", 1f);
            cc.Play(transform.position);
        }
        
    }

    void OnParticleCollision(GameObject obj)
    {
        obj.GetComponent<Parameters>().Damaged(1);
    }

    public void OnParticleSystemStopped()
    {
        cc.End();
    }

    public void Stop()
    {
        isPlayed = false;
    }

    private void Fire()
    {
        beam.Play();
        beam2.Play();
    }

    public void SetTarget(GameObject obj)
    {
        target = obj;
    }
}
