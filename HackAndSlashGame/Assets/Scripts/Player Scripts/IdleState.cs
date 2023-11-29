using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    private double timeOnDown;

    //use override keyword to override methods of base class
    public override void OnEnter()
    {
        //Debug.Log("Idle");
        animator.SetBool("canMove", true);
        animator.SetBool("isAttacking", false);
    }

    public override void OnUpdate() 
    {

        if (false)
        {
            if(Input.GetMouseButtonDown(0))
            {
                stateController.ChangeCurrentState(new LightAttack1State());
            }
        }
    }
}
