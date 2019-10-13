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
        if (stateInfo.IsName("Base Layer.Idle")) isAttacking = false;
        stateInfo = animator.GetCurrentAnimatorStateInfo(0);
    }

    void OnTriggerStay(Collider collider)
    {
        if (!isAttacking && stateInfo.IsName("Base Layer.Hanmmer"))
        {
            isAttacking = true;
            he.Play(transform.position);
            collider.gameObject.GetComponent<Parameters>().Damaged(15);
        }

        if (!isAttacking && stateInfo.IsName("Base Layer.Hanmmer_strong"))
        {
            isAttacking = true;
            he.Play(transform.position);
            collider.gameObject.GetComponent<Parameters>().Damaged(25);
        }
    }
}
