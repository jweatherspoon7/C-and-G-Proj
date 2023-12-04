using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAttack3State : BaseAttack
{
    bool inAnimation = false;
    LightAttack3SSMBhvr SSMBehavior;
    LightAttack3StateBvhr attackBehaviour;

    //script for first move in a light combo set
    public override void OnEnter()
    {
        Debug.Log("Enter LightAttack3");
        SSMBehavior = animator.GetBehaviour<LightAttack3SSMBhvr>();
        attackBehaviour = animator.GetBehaviour<LightAttack3StateBvhr>();

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

        if (inAnimation && attackBehaviour.inUpdate)
        {
            stateController.ChangeState(new IdleState());
        }
    }

    public override void OnExit()
    {
        Debug.Log("End LightAttack3");
        animator.SetBool("nextAttack", false);
        base.OnExit();
    }
}
