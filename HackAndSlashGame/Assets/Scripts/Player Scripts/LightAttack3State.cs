using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAttack3State : BaseAttack
{
    bool inAnimation = false;
    LightAttack3SSMBhvr SSMBehavior = animator.GetBehaviour<LightAttack3SSMBhvr>();

    //script for first move in a light combo set
    public override void OnEnter()
    {
        Debug.Log("Enter LightAttack3");
        base.OnEnter();
        animator.SetBool("nextAttack", true);
        animator.SetTrigger("attack3Trig");
    }

    public override void OnUpdate()
    {
        if (SSMBehavior.inSubState && !inAnimation)
        {
            inAnimation = true;
        }

        if (inAnimation)
        {
            stateController.ChangeState(new IdleState());
        }
    }

    public override void OnExit()
    {
        Debug.Log("End LightAttack3");
        base.OnExit();
    }
}
