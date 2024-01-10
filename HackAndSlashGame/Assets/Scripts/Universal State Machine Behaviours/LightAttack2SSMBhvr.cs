using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAttack2SSMBhvr : StateMachineBehaviour
{
    [HideInInspector]
    public bool inSubState = false;
    EnemyController enemyController;

    override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        inSubState = true;

        if (animator.gameObject.tag.Equals("Enemy"))
        {
            Debug.Log("attack 2");
            enemyController = animator.gameObject.GetComponent<EnemyController>();
            float rand = Random.Range(0, 1.0f);

            if (rand <= 0.5)
            {
                animator.SetInteger("AttackInt", 3);
            }
            else
            {
                animator.SetInteger("AttackInt", 0);
            }
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
