using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAttack3 : BaseAttack
{
    //script for first move in a light combo set
    public override void OnEnter()
    {
        base.OnEnter();
        animator.SetTrigger("lightAttack3Trig");
    }

    public override void OnUpdate()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("LightAttack3"))
        {
            stateController.ChangeCurrentState(new IdleState());
        }
    }
}
