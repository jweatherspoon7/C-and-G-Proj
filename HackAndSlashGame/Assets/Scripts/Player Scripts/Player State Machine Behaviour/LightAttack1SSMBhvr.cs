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
        }
     }
    
    override public void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    {
        if (animator.gameObject.tag.Equals("Enemy"))
        {
            enemyTarget.SetCanRotate(true);
            animator.SetBool("onCooldown", true);
        }

        inSubState = false;
    }
}
