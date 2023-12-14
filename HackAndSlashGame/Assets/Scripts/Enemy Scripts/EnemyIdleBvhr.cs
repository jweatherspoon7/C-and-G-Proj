using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleBvhr : StateMachineBehaviour
{
    PlayerTargeting playerTargeting;
    GameObject enemy;
    Vector3 initPosition;
    private float turnSmoothTime = 0.5f;
    private float turnSmoothVelocity;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isWalking", false);
        playerTargeting = animator.gameObject.GetComponent<PlayerTargeting>();
        enemy = animator.gameObject;

        initPosition = enemy.transform.position;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 playerRay = playerTargeting.GetPlayerRay();


        float targetAngle = Quaternion.LookRotation(playerRay.normalized).eulerAngles.y;

        //Smooths the player angle over time. 
        float angle = Mathf.SmoothDampAngle(enemy.transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

        enemy.transform.rotation = Quaternion.Euler(0, angle, 0);


        if (playerRay.magnitude > 5)
        {
            //Walk to player if they are far away
            animator.SetInteger("yDirectionBlend", 1);
            animator.SetBool("isWalking", true);
        }
        else 
        {
            enemy.transform.position = initPosition;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
