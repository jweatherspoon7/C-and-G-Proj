using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParryStateBvhr : StateMachineBehaviour
{
    [HideInInspector]
    public bool inSubState = false;
    State nextState = new MovementState();

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        inSubState = true;
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.CompareTag("Player"))
        {
            animator.SetBool("isParrying", false);
            animator.gameObject.GetComponent<StateController>().ChangeState(nextState);
        }
        inSubState = false;
    }

    public void SetNextState(State state) { if(state != null) nextState = state; }
}