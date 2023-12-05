using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAttack2SSMBhvr : StateMachineBehaviour
{
    [HideInInspector]
    public bool inSubState = false;

    override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        Debug.Log("Enter Attack2 Anim");
        inSubState = true;
    }

    override public void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    {
        Debug.Log("End Attack2 Anim");
        inSubState = false;
    }
}
