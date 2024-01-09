using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    private IdleStateBehavior behavior;

    //use override keyword to override methods of base class
    public override void OnEnter()
    {
        animator.SetBool("canMove", true);
        animator.SetBool("isAttacking", false);
        animator.SetBool("isWalking", false);
        animator.SetBool("attack1Bool", false);
        animator.SetBool("attack2Bool", false);
        animator.SetBool("attack3Bool", false);
        behavior = animator.GetBehaviour<IdleStateBehavior>();
    }

    public override void OnUpdate() 
    {
        nextState = ListenForAttackInputs();

        if (behavior.inUpdate)
        {
            stateController.ChangeState(nextState);
        }
    }
}
