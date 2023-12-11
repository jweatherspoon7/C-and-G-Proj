using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAttack3StateBvhr : StateMachineBehaviour
{
    [HideInInspector]
    public bool inEnter = false;

    [HideInInspector]
    public bool inUpdate = false;

    private AttackRaycasts attackRaycasts;

    private int knockBack = 10;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        inEnter = true;
        attackRaycasts = animator.gameObject.GetComponent<AttackRaycasts>();
        attackRaycasts.StartRaycasts(knockBack);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        inUpdate = true;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        attackRaycasts.EndRaycasts();
        //End Raycasts
        inEnter = false;
        inUpdate = false;
    }
}
