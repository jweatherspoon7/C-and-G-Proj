using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartThrustAttackState : BaseAttack
{
    public override void OnEnter()
    {
        base.OnEnter();
        animator.SetBool("ThrustAttackBool", true);
        animator.SetBool("MouseButton0DownHold", true);
        Debug.Log("StartThrustAttack");
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("StartThrustAttack"))
        {
            if(shouldCombo)
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
