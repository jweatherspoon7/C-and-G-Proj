using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAttack1SSMBhvr : StateMachineBehaviour
{
    [HideInInspector]
    public bool inSubState = false;
    PlayerTargeting enemyTarget;

     override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
     {
        inSubState = true;

        if (animator.gameObject.tag.Equals("Enemy"))
        {
            enemyTarget = animator.gameObject.GetComponent<PlayerTargeting>();
            enemyTarget.SetCanRotate(false);
            float rand = Random.Range(0, 1.0f);

            Debug.Log(rand);
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
            enemyTarget.SetCanRotate(true);
            animator.SetBool("onCooldown", true);
            enemyTarget.StartCooldown(Random.Range(0.2f, 2));
        }

        inSubState = false;
    }
}
