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
        float vertInput = Input.GetAxisRaw("Vertical");
        float horizInput = Input.GetAxisRaw("Horizontal");
        Vector3 inputMag = new Vector3(vertInput, 0, horizInput).normalized;

        if (behavior.inUpdate)
        {
            if(Input.GetMouseButtonDown(0))
            {
                stateController.ChangeState(new LightAttack1State());
            }
            else if(inputMag.magnitude >= 0.01)
            {
                stateController.ChangeState(new WalkState());
            }
        }
    }
}
