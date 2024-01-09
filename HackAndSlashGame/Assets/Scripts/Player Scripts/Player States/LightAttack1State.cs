using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class to represent Attack1 substatemachine
public class LightAttack1State : BaseAttack
{
    bool inAttack = false;
    LightAttack1SSMBhvr SSMBehavior;
    LightAttack1StateBhvr attackBehaviour;
    LightAttack1FinisherBhvr finisherBehaviour;

    public override void OnEnter()
    {
        SSMBehavior = animator.GetBehaviour<LightAttack1SSMBhvr>();
        attackBehaviour = animator.GetBehaviour<LightAttack1StateBhvr>();
        finisherBehaviour = animator.GetBehaviour<LightAttack1FinisherBhvr>();

        base.OnEnter();
        animator.SetBool("attack1Bool", true);
    }

    public override void OnUpdate()
    {
        if (SSMBehavior.inSubState)
        {
            inAttack = true;
            base.OnUpdate();

            if((attackBehaviour.inEnter || finisherBehaviour.inEnter) && shouldCombo)
            {
                stateController.ChangeState(new LightAttack2State());
            }
        }

        if(inAttack && !SSMBehavior.inSubState)
        {
            stateController.ChangeState(new MovementState());
        }
    }

    public override void OnExit() 
    {
        animator.SetBool("attack1Bool", false);
        finisherBehaviour.inExit = false;
        if (!shouldCombo)
        {
            base.OnExit();
        }

    }
}
