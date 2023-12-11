using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAttack2State : BaseAttack
{
    bool inAnimation = false;
    LightAttack2StateBvhr attackBehaviour;
    LightAttack2SSMBhvr SSMBehavior;

    public override void OnEnter()
    {
        Debug.Log("Enter LightAttack2");
        attackBehaviour = animator.GetBehaviour<LightAttack2StateBvhr>();
        SSMBehavior = animator.GetBehaviour<LightAttack2SSMBhvr>();

        base.OnEnter();
        animator.SetBool("attack2Bool", true);
    }

    public override void OnUpdate() 
    {
        if (SSMBehavior.inSubState)
        {
            inAnimation = true;
            base.OnUpdate();

            if (attackBehaviour.inEnter && shouldCombo)
            {
                stateController.ChangeState(new LightAttack3State());
            }
        }

        if (inAnimation && !SSMBehavior.inSubState)
        {
            stateController.ChangeState(new IdleState());
        }
    }

    public override void OnExit() 
    {
        animator.SetBool("attack2Bool", false);
        if (!shouldCombo)
        {
            base.OnExit();
        }
    }
}