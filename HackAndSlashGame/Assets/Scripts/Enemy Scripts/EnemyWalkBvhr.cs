using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalkBvhr : StateMachineBehaviour
{
    PlayerTargeting playerTargeting;
    Transform transform;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerTargeting = animator.gameObject.GetComponent<PlayerTargeting>();
        transform = animator.gameObject.transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 playerRay = playerTargeting.GetPlayerRay();

        if (!animator.GetBool("onCooldown"))
        {
            if(playerRay.magnitude <= 1)
            {
                animator.SetTrigger("attack1Trig");
            }
        }
        else
        {
            if(playerRay.magnitude <= 5)
            {
                animator.SetBool("isWalking", false);
            }
        }

        Quaternion lookAtRotation = Quaternion.LookRotation(playerRay.normalized);
        lookAtRotation.x = 0;
        lookAtRotation.z = 0;

        transform.rotation = lookAtRotation;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


}
