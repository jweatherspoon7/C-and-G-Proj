using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParryState : State
{ 
    ParryStateBvhr behaviour = animator.GetBehaviour<ParryStateBvhr>();
    public override void OnEnter()
    {
        Debug.Log("enter parry");
        animator.SetBool("isParrying", true);
    }

    public override void OnUpdate()
    {
        nextState = ListenForAttackInputs(false);

        behaviour.SetNextState(nextState);
    }

    public override void OnExit()
    {
        Debug.Log("exit parry");
    }
}
