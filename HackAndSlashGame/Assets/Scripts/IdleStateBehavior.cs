using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleStateBehavior : StateMachineBehaviour
{

    [HideInInspector]
    public enum status
    {
        notStarted,
        enter,
        update,
        exit
    }

    public status currentStatus = status.notStarted;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        currentStatus = status.enter;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        currentStatus = status.update;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        currentStatus = status.exit;
    }

}
