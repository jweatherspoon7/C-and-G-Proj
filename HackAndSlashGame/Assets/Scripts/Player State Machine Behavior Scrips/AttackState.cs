using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : StateMachineBehaviour
{
    protected bool shouldCombo = false;
    public string nextState;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isAttacking", true);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(Input.GetMouseButtonUp(0))
        {
            shouldCombo = true;
        }

        if(stateInfo.normalizedTime > 0.9)
        {
            animator.SetBool("canMove", true);
            animator.SetBool("isAttacking", false);
        }
    }
}
