using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAttack2State : BaseAttack
{
    public override void OnEnter()
    {
        index = 1;
        //comboSSMBhvr = animator.GetBehaviour<Attack2SSMBhvr>();
        nextAttack = new LightAttack3State();

        Debug.Log("enter attack 2");
        base.OnEnter();
        animator.SetBool("attack2Bool", true);
    }

    public override void OnExit() 
    {
        animator.SetBool("attack2Bool", false);
        base.OnExit();
        Debug.Log("exit attack 2");
    }
}