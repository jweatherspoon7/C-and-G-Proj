using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAttack1 : BaseAttack
{
    private bool nextAttack = false;
    public override void OnEnter()
    {
        base.OnEnter();
        animator.SetBool("LightAttack1Bool", true);
        Debug.Log("Enter attack 1");
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("LightAttack1"))
        {
            if(shouldCombo && animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.8)
            {
                nextAttack = true;
                stateController.ChangeCurrentState(new LightAttack2());
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

        animator.SetBool("LightAttack1Bool", false);
    }
}
