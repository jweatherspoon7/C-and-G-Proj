using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAttack3SSMBhvr : StateMachineBehaviour
{
    [HideInInspector]
    public bool inSubState = false;

    override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        Debug.Log("Enter Attack3 Anim");
        inSubState = true;
    }

    override public void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    {
        Debug.Log("End Attack3 Anim");
        inSubState = false;
    }
}
