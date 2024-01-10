using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAttack1SSMBhvr : StateMachineBehaviour
{
    [HideInInspector]
    public bool inSubState = false;
    EnemyController enemyController;

     override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
     {
        inSubState = true;

        if (animator.gameObject.tag.Equals("Enemy"))
        {
            Debug.Log("attack 1");

            enemyController = animator.gameObject.GetComponent<EnemyController>();
            float rand = Random.Range(0, 1.0f);

            if(rand <= 0.6)
            {
                animator.SetInteger("AttackInt", 2);
            }
            else
            {
                animator.SetInteger("AttackInt", 0);
            }
        }
    }

    override public void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    {
        if (animator.gameObject.tag.Equals("Enemy"))
        {
            animator.SetBool("onCooldown", true);
            enemyController.StartCooldown(Random.Range(0.2f, 2));
        }

        inSubState = false;
    }
}
