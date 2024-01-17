using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JonathanMovementBhvr : StateMachineBehaviour
{
    private GameObject gameObject;

    private JonathanController controller;

    //for smooth damp on movement
    private float smoothTime = 0.05f;
    private float smoothVelocity;
    private bool startedAttack = false;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        gameObject = animator.gameObject;

        controller = gameObject.GetComponent<JonathanController>();
    }


    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
    {
        Vector3 playerRay = controller.GetPlayerRay();
        float movementTarget = 0;

        if (playerRay.magnitude >= 1.3)
        {
            movementTarget = 1;
        }
        else if(!startedAttack)
        {
            string attackTrig = "Combo" + Random.Range(1, 4) + "Trig"; 
            animator.SetTrigger(attackTrig);
            startedAttack = true;
        }

        float movementBlend = Mathf.SmoothDamp(animator.GetFloat("movementBlend"), movementTarget, ref smoothVelocity, smoothTime);
        animator.SetFloat("movementBlend", movementBlend);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        startedAttack = false;
        animator.SetFloat("movementBlend", 0);
    }
}
