using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleBvhr : StateMachineBehaviour
{
    PlayerTargeting playerTargeting;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerTargeting = animator.gameObject.GetComponent<PlayerTargeting>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 playerRay = playerTargeting.GetPlayerRay();

        if(playerRay.magnitude > 5)
        {
            animator.SetBool("isWalking", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
