using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParryState : State
{ 
    public override void OnEnter()
    {
        animator.SetTrigger("parryTrig");
    }
}
