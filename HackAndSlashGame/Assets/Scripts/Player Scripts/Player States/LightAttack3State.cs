using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAttack3State : BaseAttack
{
    public override void OnEnter()
    {
        index = 2;
        //comboSSMBhvr = animator.GetBehaviour<Attack3SSMBhvr>();
        nextAttack = new LightAttack1State();

        Debug.Log("enter attack 3");
        base.OnEnter();
        animator.SetBool("attack3Bool", true);
    }

    public override void OnExit()
    {
        animator.SetBool("attack3Bool", false);
        base.OnExit();
        Debug.Log("exit attack 3");
    }
}
