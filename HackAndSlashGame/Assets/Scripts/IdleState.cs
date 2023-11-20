using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    private double timeOnDown;

    //use override keyword to override methods of base class
    public override void OnEnter()
    {
        Debug.Log("Idle");
        animator.SetBool("canMove", true);
        animator.SetBool("isAttacking", false);
    }

    public override void OnUpdate() 
    {
        if(startAnimation) //will only update if animation has started
        {
            if (animator.GetBool("canAttack"))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    timeOnDown = time;
                }

                //to detect hold vs click
                if (Input.GetMouseButton(0) && time - timeOnDown > 0.25)
                {
                    stateController.ChangeCurrentState(new StartThrustAttackState());
                }

                if (Input.GetMouseButtonUp(0))
                {
                    stateController.ChangeCurrentState(new LightAttack1State());
                }
            }
        }
    }
}
