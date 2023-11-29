using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAttack1SSMBhvr : StateMachineBehaviour
{
    [HideInInspector]
    public bool inEnter = false;

    [HideInInspector]
    public bool inUpdate = false;

    [HideInInspector]
    public bool inExit = false;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Enter");
        inEnter = true;
        inExit = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        inUpdate = true;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Exit");
        inEnter = false;
        inUpdate = false;
        inExit = true;
    }
}
