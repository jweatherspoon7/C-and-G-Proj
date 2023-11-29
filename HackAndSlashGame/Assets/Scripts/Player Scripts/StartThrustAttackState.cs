using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartThrustAttackState : BaseAttack
{
    public override void OnEnter()
    {
        animator.SetBool("ThrustAttackBool", true);
        animator.SetBool("MouseButton0DownHold", true);
        animator.SetBool("canMove", false);
        animator.SetBool("isAttacking", true);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("StartThrustAttack"))
        {
            if(Input.GetMouseButtonUp(0))
            {
                stateController.ChangeCurrentState(new ThrustAttackState());
            }
        }
    }

    public override void OnExit()
    {
        animator.SetBool("MouseButton0DownHold", false);
    }
}
