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
        animator.SetBool("nextAttack",true);
        animator.SetTrigger("attack2Trig");
    }

    public override void OnUpdate() 
    {
        Debug.Log(SSMBehavior.inSubState);
        if(SSMBehavior.inSubState && !inAnimation)
        {
            inAnimation = true;
            animator.SetBool("nextAttack", false);
        }
        
        if(inAnimation)
        {
            base.OnUpdate();

            if (shouldCombo)
            {
                stateController.ChangeState(new LightAttack3State());
            }

            if (!SSMBehavior.inSubState && !shouldCombo)
            {
                stateController.ChangeState(new IdleState());
            }
        }
    }

    public override void OnExit() 
    {
        if (!shouldCombo)
        {
            animator.SetBool("nextAttack", false);
            base.OnExit();
        }
    }
}