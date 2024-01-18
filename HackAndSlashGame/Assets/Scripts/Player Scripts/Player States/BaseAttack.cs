using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static BaseStateMachineBehaviour;

public class BaseAttack : State
{
    protected bool shouldCombo = false; //checks if the state will be change to next move in the combo set
    protected bool inAnimation = false; //checks if we are in the substate machine

    protected AttackBvhr attackBvhr;
    protected AttackFinisherBhvr finisherBhvr;
    protected ComboSSMBhvr comboSSMBhvr;

    protected State nextAttack;
    protected int index = 0;

    public override void OnEnter()
    {
        comboSSMBhvr = animator.GetBehaviours<ComboSSMBhvr>()[index];
        attackBvhr = animator.GetBehaviours<AttackBvhr>()[index];
        finisherBhvr = animator.GetBehaviours<AttackFinisherBhvr>()[index];

        animator.SetBool("canMove", false);
        animator.SetBool("isAttacking", true);
    }
    public override void OnUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shouldCombo = true;
            Debug.Log("shouldCombo " + shouldCombo);
        }

        CheckSSM();

        if (inAnimation)
        {
            if((attackBvhr.state == StateMachineState.inState || finisherBhvr.state == StateMachineState.inState) && shouldCombo) //go to next attack if left click
            {
                Debug.Log("Next Attack");
                stateController.ChangeState(nextAttack);
            }
            else if (finisherBhvr.state == StateMachineState.inState && !shouldCombo) 
            {
                State animationCancel = InputListener();

                if(animationCancel != null)
                {
                    stateController.ChangeState(animationCancel);
                }
            }
        }
    }

    public override void OnExit()
    {
        //comboSSMBhvr.state = StateMachineState.notInState;
        //attackBvhr.state = StateMachineState.notInState;
        //finisherBhvr.state = StateMachineState.notInState;

        if(!shouldCombo)
        {
            animator.SetBool("canMove", true);
            animator.SetBool("isAttacking", false);
        }
    }

    //method to check for inputs when in finisher animation to animation cancel
    private State InputListener()
    {
        State next = null;

        float horizInput = Input.GetAxisRaw("Horizontal");
        float vertInput = Input.GetAxisRaw("Vertical");
        float mag = new Vector3(vertInput, 0, horizInput).normalized.magnitude;

        //cancel finisher animation if player wants to parry or move
        if (Input.GetMouseButtonDown(1))
        {
            next = new ParryState();
        }
        else if(mag >= 0.1)
        {
            next = new MovementState();
        }

        return next;
    }

    //method to check if we are in the combo substate machine
    private void CheckSSM()
    {
        switch (comboSSMBhvr.state)
        {
            case StateMachineState.inState:
                inAnimation = true;
                break;

            case StateMachineState.notInState:
                if (inAnimation) //go to idle if player does nothing when animation ends
                {
                    stateController.ChangeState(new MovementState());
                }
                break;
        }
    }

}
