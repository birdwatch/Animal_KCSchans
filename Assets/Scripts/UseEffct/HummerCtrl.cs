using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HummerCtrl : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private HummarEffect he;

    private string ancestor;
    private bool isAttacking = false;
    private AnimatorStateInfo stateInfo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        stateInfo = animator.GetCurrentAnimatorStateInfo(0);
    }

    void OnTriggerStay(Collider collider)
    {
        
        if (stateInfo.IsName("Base Layer.Hanmmer"))
            he.Play(transform.position);
    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider);
        if (stateInfo.IsName("Base Layer.Hanmmer_strong"))
            he.Play(transform.position);

        if (stateInfo.IsName("Base Layer.Hanmmer"))
            he.Play(transform.position);
    }

    
}
