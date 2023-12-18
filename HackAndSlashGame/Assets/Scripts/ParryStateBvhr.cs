using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParryStateBvhr : StateMachineBehaviour
{
    [HideInInspector]
    public bool inSubState = false;

    override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        inSubState = true;
    }

    override public void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    {
        if (animator.CompareTag("Player"))
        {
            animator.gameObject.GetComponent<StateController>().ChangeState(new IdleState());
        }
        inSubState = false;
    }
}