using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboSSMBhvr : BaseStateMachineBehaviour
{
    private GameObject gameObject;
    private JonathanController jonathanController;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        state = StateMachineState.inState;
        gameObject = animator.gameObject;

        if (animator.gameObject.CompareTag("Boss"))
        {
            jonathanController = gameObject.GetComponent<JonathanController>();
            jonathanController.ResetHeading();
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    {
        state = StateMachineState.notInState;

        if (animator.gameObject.CompareTag("Boss"))
        {
            animator.SetBool("OnCooldown", true);
            jonathanController.StartCooldown(Random.Range(0,1.5f));
        }
    }
}
