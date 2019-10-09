using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HummarEffect : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem star;

    [SerializeField]
    private ParticleSystem damaged;

    private bool isPlayed = false;

    public void Play(Vector3 pos)
    {
        if (!isPlayed)
        {
            damaged.transform.position = pos;
            star.transform.position = pos;
            damaged.Play();
            star.Play();
        }
    }

    private void OnParticleSystemStopped()
    {
        isPlayed = false;
    }
}
