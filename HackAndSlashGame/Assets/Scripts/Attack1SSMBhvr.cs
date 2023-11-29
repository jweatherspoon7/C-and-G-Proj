using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack1SSMBhvr : StateMachineBehaviour
{
    [HideInInspector]
    public bool inEnter = false;
    public bool inUpdate = false;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Start Raycasts
        inEnter = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        inUpdate = true;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //End raycasts
        inEnter = false;
        inUpdate = false;
    }
}
