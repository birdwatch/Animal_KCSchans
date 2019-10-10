using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamHittedEffect : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem ps;
    private bool isPlayed = false;

    public void Play()
    {
        if(!isPlayed) ps.Play();
        isPlayed = true;
    }

    public void OnParticleSystemStopped()
    {
        isPlayed = false;
    }
}
