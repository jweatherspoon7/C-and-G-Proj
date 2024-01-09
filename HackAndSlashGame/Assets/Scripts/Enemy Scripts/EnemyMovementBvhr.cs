using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementBvhr : StateMachineBehaviour
{
    private PlayerTargeting playerTargeting;

    //for smooth damp on movement
    private float smoothTime = 0.05f;
    private float smoothVelocity;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerTargeting = animator.gameObject.GetComponent<PlayerTargeting>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 playerRay = playerTargeting.GetPlayerRay();
        int movementTarget = 0;

        if (animator.GetBool("onCooldown"))
        {
            if( playerRay.magnitude < 2)
            {
                Debug.Log("cooldown backup");
                movementTarget = -1;
            }
            else if(playerRay.magnitude >= 3)
            {
                Debug.Log("cooldown move to player");
                movementTarget = 1;
            }
            else
            {
                Debug.Log("cooldown stand still");
                movementTarget = 0;
            }
        }
        else
        {
            if(playerRay.magnitude > 1.1)
            {
                movementTarget = 1;
            }
            else
            {
                animator.SetInteger("AttackInt", 1);
            }
        }

        float movementBlend = Mathf.SmoothDamp(animator.GetFloat("movementBlend"), movementTarget, ref smoothVelocity, smoothTime);
        animator.SetFloat("movementBlend", movementBlend);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetFloat("movementBlend", 0);
    }
}
