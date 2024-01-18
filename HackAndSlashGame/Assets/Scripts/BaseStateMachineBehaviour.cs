using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStateMachineBehaviour : StateMachineBehaviour
{
    // enum to tell if we are in a state or not
    public enum StateMachineState
    {
        inState,
        notInState
    }

    public StateMachineState state = StateMachineState.notInState;
}
