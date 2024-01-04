using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementBvhr : StateMachineBehaviour
{
    PlayerTargeting playerTargeting;
    bool onCooldown;

    //use to keep enemy from running from the player
    bool hasBackedup = false;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerTargeting = animator.gameObject.GetComponent<PlayerTargeting>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 playerRay = playerTargeting.GetPlayerRay();
        onCooldown = animator.GetBool("onCooldown");

        if (onCooldown)
        {
            if(playerRay.magnitude <= 5 && !hasBackedup)
            {
                animator.SetFloat("movementBlend", -1);
            }
            else if(playerRay.magnitude > 5.5)
            {
                animator.SetFloat("movementBlend", 1);
            }
            else
            {
                hasBackedup = true;
                animator.SetFloat("movementBlend", 0);
            }
        }
        
        if(!onCooldown)
        {
            if(playerRay.magnitude > 1.2)
            {
                animator.SetFloat("movementBlend", 1);
            }
            else
            {
                animator.SetTrigger("attack1Trig");
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        hasBackedup = false;
        animator.SetFloat("movementBlend", 0);
    }
}
