using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrustAttackState : BaseAttack
{
    public override void OnEnter()
    {
        base.OnEnter();
        animator.SetBool("ThrustAttackBool", true);
        Debug.Log("ThrustAttack");
    }

    public override void OnUpdate()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("ThrustAttack"))
        {
            stateController.ChangeCurrentState(new IdleState());
        }
    }

    public override void OnExit()
    {
        base.OnExit();
        animator.SetBool("ThrustAttackBool", false);
    }
}
