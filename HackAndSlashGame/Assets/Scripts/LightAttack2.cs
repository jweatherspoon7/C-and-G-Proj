using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAttack2 : BaseAttack
{

    //script for first move in a light combo set
    public override void OnEnter()
    {
        base.OnEnter();
        animator.SetTrigger("lightAttack2Trig");
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("LightAttack2"))
        {
            if (shouldCombo)
            {
                Debug.Log("attack 1 to 2");
                stateController.ChangeCurrentState(new LightAttack3());
            }
            else
            {
                Debug.Log("attack 1 to idle");
                stateController.ChangeCurrentState(new IdleState());
            }
        }
    }
}