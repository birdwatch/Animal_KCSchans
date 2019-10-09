using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleCtrl : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem circle;

    [SerializeField]
    private BeamCtrl bc;

    public void Play(Vector3 pos)
    {
        transform.position = pos;
        circle.Play();
    }

    public void End()
    {
        circle.Stop();
        Invoke("s", 1f);
    }

    private void s()
    {
        bc.Stop();
    }
}
