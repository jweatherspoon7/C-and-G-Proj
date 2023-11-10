using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    State currentState;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        ChangeCurrentState(new IdleState());
    }

    // Update is called once per frame
    void Update()
    {
        currentState.OnStateUpdate();
    }

    void ChangeCurrentState(State newState)
    {
        if(currentState != null)
        {
            currentState.OnStateExit();
        }
        currentState = newState;
        currentState.OnStateEnter(this, anim);
    }
}
