using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitCtrl : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private ParticleSystem smoke;

    private AnimatorStateInfo stateInfo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        AttackCtrl();
    }

    private void AttackCtrl()
    {
        if (stateInfo.IsName("Base Layer.Hanmmer_strong")) Invoke("S", 0.3f); 
        else if (stateInfo.IsName("Base Layer.Idle")) smoke.Stop();
    }

    private void S()
    {
        smoke.Play();
    }
}
