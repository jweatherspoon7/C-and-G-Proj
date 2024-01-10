using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAttack3SSMBhvr : StateMachineBehaviour
{
    [HideInInspector]
    public bool inSubState = false;
    EnemyController enemyController;

    override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        inSubState = true;

        if (animator.gameObject.tag.Equals("Enemy"))
        {
            Debug.Log("attack 3");
            enemyController = animator.gameObject.GetComponent<EnemyController>();
            animator.SetInteger("AttackInt", 0);
        }
    }

    override public void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    {
        inSubState = false;

        if (animator.gameObject.tag.Equals("Enemy"))
        {
            animator.SetBool("onCooldown", true);
            enemyController.StartCooldown(Random.Range(0.2f, 2));
        }
    }
}
