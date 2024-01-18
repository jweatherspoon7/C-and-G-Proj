using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBvhr : BaseStateMachineBehaviour
{
    public int damage = 0;

    private GameObject gameObject;

    private AttackRaycasts attackRaycasts;
    private JonathanController jonathanController;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        state = StateMachineState.inState;
        gameObject = animator.gameObject; 

        attackRaycasts = gameObject.GetComponent<AttackRaycasts>();
        attackRaycasts.StartRaycasts(damage);

        if (animator.gameObject.CompareTag("Boss"))
        {
            jonathanController = gameObject.GetComponent<JonathanController>();
            jonathanController.SetTurnEnabled(false);
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {  }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        state = StateMachineState.notInState;
        attackRaycasts.EndRaycasts();
        if (animator.gameObject.CompareTag("Boss"))
        {
            jonathanController.SetTurnEnabled(true);
            jonathanController.ResetHeading();
        }
    }
}
