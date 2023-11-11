using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAttack1 : BaseAttack
{
    public override void OnEnter()
    {
        Debug.Log("Enter attack 1");
        base.OnEnter();
        animator.SetTrigger("lightAttack1Trig");
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("LightAttack1"))
        {
            if(shouldCombo)
            {
                Debug.Log("attack 1 to 2");
                stateController.ChangeCurrentState(new LightAttack2());
            }
            else
            {
                Debug.Log("attack 1 to idle");
                stateController.ChangeCurrentState(new IdleState());
            }
        }
    }
}
