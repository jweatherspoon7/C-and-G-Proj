using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    private double timeOnDown;
    private IdleStateBehavior behavior;

    //use override keyword to override methods of base class
    public override void OnEnter()
    {
        Debug.Log("Idle");
        animator.SetBool("canMove", true);
        animator.SetBool("isAttacking", false);
        behavior = animator.GetBehaviour<IdleStateBehavior>();
    }

    public override void OnUpdate() 
    {

        if (behavior.inUpdate)
        {
            if(Input.GetMouseButtonDown(0))
            {
                stateController.ChangeState(new LightAttack1State());
            }
        }
    }
}
