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
        SSMBehavior = animator.GetBehaviour<LightAttack3SSMBhvr>();
        attackBehaviour = animator.GetBehaviour<LightAttack3StateBvhr>();

        base.OnEnter();
        animator.SetBool("attack3Bool", true);
    }

    public override void OnUpdate()
    {
        if (SSMBehavior.inSubState && !inAnimation)
        {
            inAnimation = true;
        }

        if (inAnimation && attackBehaviour.inUpdate)
        {
            stateController.ChangeState(new MovementState());
        }
    }

    public override void OnExit()
    {
        animator.SetBool("attack3Bool", false);
        base.OnExit();
    }
}
