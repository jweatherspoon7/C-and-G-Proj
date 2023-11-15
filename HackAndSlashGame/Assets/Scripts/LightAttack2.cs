using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAttack2 : BaseAttack
{
    private bool nextAttack = false;
    //script for first move in a light combo set
    public override void OnEnter()
    {
        base.OnEnter();
        animator.SetBool("LightAttack2Bool", true);
        Debug.Log("LightAttack2");
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("LightAttack2"))
        {
            if (shouldCombo && animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.8)
            {
                nextAttack = true;
                stateController.ChangeCurrentState(new LightAttack3());
            }
            else if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.8)
            {
                stateController.ChangeCurrentState(new IdleState());
            }
        }
    }

    public override void OnExit()
    {
        if (!nextAttack)
        {
            base.OnExit();
        }

        animator.SetBool("LightAttack2Bool", false);
    }
}