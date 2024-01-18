using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class to represent Attack1 substatemachine
public class LightAttack1State : BaseAttack
{
    public override void OnEnter()
    {
        //comboSSMBhvr = animator.GetBehaviour<Attack1SSMBhvr>();
        nextAttack = new LightAttack2State();

        Debug.Log("enter attack 1");
        base.OnEnter();
        animator.SetBool("attack1Bool", true);
    }

    public override void OnExit() 
    {
        animator.SetBool("attack1Bool", false);
        base.OnExit();
        Debug.Log("exit attack 1");
    }
}
