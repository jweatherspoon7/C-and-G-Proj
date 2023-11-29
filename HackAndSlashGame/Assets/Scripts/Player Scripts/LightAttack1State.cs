using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class to represent Attack1 substatemachine
public class LightAttack1State : BaseAttack
{

    LightAttack1SSMBhvr SSMBehavior = animator.GetBehaviour<LightAttack1SSMBhvr>();
    public override void OnEnter()
    {
        Debug.Log("Attack1");
        base.OnEnter();
        animator.SetTrigger("attack1Trig");
    }

    public override void OnUpdate()
    {
        if(SSMBehavior.inUpdate)
        {
            stateController.ChangeState(new IdleState());
        }
    }

    public override void OnExit() 
    { 
        if(!shouldCombo)
        {
            animator.SetBool("canMove", true);
            animator.SetBool("isAttacking", false);
        }
    }
}
