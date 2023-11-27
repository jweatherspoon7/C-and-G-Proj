using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseAttack : State
{
    protected bool shouldCombo = false; //checks if the state will be change to next move in the combo set
    protected bool finisher = false; //checks if its the final move of the combo set
    protected string stateName; //always use statename when using OnUpdate()
    protected State nextAttackState;

    public override void OnEnter()
    {
        animator.SetBool("canMove", false);
        animator.SetBool("isAttacking", true);
        animator.SetBool(stateName + "Bool", true);

        //Debug.Log(stateName);
    }
    public override void OnUpdate()
    {
        if(Input.GetMouseButtonUp(0))
        {
            shouldCombo = true;
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName(stateName)) 
        {
            if (!finisher) //if not finisher listen for next inputs
            {
                listenForNextInput();
            }
            else //if finisher go back to idle
            {
                stateController.ChangeCurrentState(new IdleState());
            }
        }
    }

    public override void OnExit()
    {
        if(!shouldCombo)
        {
            animator.SetBool("canMove", true);
            animator.SetBool("isAttacking", false);

        }
        animator.SetBool(stateName + "Bool", false);
    }

    private void listenForNextInput()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.6)
        {
            if(shouldCombo)
            {
                stateController.ChangeCurrentState(nextAttackState);
            }
        }
        else
        {
            //go back to idle if no next attack
            stateController.ChangeCurrentState(new IdleState());
        }
    }
}
