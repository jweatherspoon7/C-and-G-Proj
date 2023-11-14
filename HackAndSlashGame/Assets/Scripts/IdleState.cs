using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    //use override keyword to override methods of base class
    public override void OnEnter()
    {
        animator.SetBool("canMove", true);
        animator.SetBool("isAttacking", false);
    }

    public override void OnUpdate() 
    {
        if (Input.GetMouseButtonDown(0) && animator.GetBool("canAttack"))  
        {
            stateController.ChangeCurrentState(new LightAttack1());
        }
    }

}
