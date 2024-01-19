using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageStateBhvr : StateMachineBehaviour
{
    GameObject gameObject;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        gameObject = animator.gameObject;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (gameObject.CompareTag("Player"))
        {
            animator.SetBool("canMove", true);
            animator.SetBool("isAttacking", false);
            animator.SetBool("attack1Bool", false);
            animator.SetBool("attack2Bool", false);
            animator.SetBool("attack3Bool", false);

            gameObject.GetComponent<StateController>().ChangeState(new MovementState());
        }
        else if (gameObject.CompareTag("Enemy"))
        {
            animator.SetFloat("attackFloat", 0);
            animator.SetBool("onCooldown", true);

            EnemyController controller = animator.gameObject.GetComponent<EnemyController>();
            controller.StartCooldown(Random.Range(0,1));
        }
    }
}
