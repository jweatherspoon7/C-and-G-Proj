using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAttack3 : BaseAttack
{
    //script for first move in a light combo set
    public override void OnEnter()
    {
        base.OnEnter();
        animator.SetBool("LightAttack3Bool", true);
        Debug.Log("LigtAttack3");
    }

    public override void OnUpdate()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("LightAttack3"))
        {
            stateController.ChangeCurrentState(new IdleState());
        }
    }

    public override void OnExit()
    {
        base.OnExit();
        animator.SetBool("LightAttack3Bool", false);
    }
}
