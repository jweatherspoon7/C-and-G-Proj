using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParryState : State
{ 
    ParryStateBvhr behaviour = animator.GetBehaviour<ParryStateBvhr>();
    public override void OnEnter()
    {
        Debug.Log("Parry");
        animator.SetTrigger("parryTrig");
    }

    public override void OnUpdate()
    {
        nextState = ListenForAttackInputs();
        if (nextState == null) nextState = ListenForMovement();
        
        behaviour.SetNextState(nextState);
    }
}
