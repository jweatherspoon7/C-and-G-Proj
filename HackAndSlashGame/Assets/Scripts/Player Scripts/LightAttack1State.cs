using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class to represent Attack1 substatemachine
public class LightAttack1State : BaseAttack
{
    public override void OnEnter()
    {
        animator.SetTrigger("attack1Trig");
    }

    public override void OnUpdate()
    { 

    }

    public override void OnExit() 
    { 
    
    }
}
