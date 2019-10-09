using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstCtrl : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play(Vector3 pos)
    {
        transform.position = pos;
        ps.Play();
    }
}
