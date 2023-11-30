using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class to represent Attack1 substatemachine
public class LightAttack1State : BaseAttack
{
    bool inAnimation = false;
    LightAttack1SSMBhvr SSMBehavior = animator.GetBehaviour<LightAttack1SSMBhvr>();
    LightAttack1StateBhvr attackBehaviour = animator.GetBehaviour<LightAttack1StateBhvr>();
    LightAttack1FinisherBhvr finisherBehaviour = animator.GetBehaviour<LightAttack1FinisherBhvr>();

    public override void OnEnter()
    {
        Debug.Log("Enter LightAttack1");
        base.OnEnter();
        animator.SetTrigger("attack1Trig");
    }

    public override void OnUpdate()
    {
        if (SSMBehavior.inSubState && !inAnimation)
        {
            Debug.Log("Attack1 Update");
            inAnimation = true;
        }

        if(inAnimation)
        {
            base.OnUpdate();

            if (shouldCombo)
            {
                stateController.ChangeState(new LightAttack2State());
            }

            if (!SSMBehavior.inSubState && !shouldCombo)
            {
                stateController.ChangeState(new IdleState());
            }
        }
    }

    public override void OnExit() 
    {
        Debug.Log("End LightAttack1");
        if(!shouldCombo)
        {
            base.OnExit();
        }
    }
}
