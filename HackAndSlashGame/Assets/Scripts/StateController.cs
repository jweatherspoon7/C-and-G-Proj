using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    State currentState;
    Animator anim;
    AttackRaycasts attackRaycasts;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        currentState = new IdleState();
        attackRaycasts = GetComponent<AttackRaycasts>();
        ChangeCurrentState(currentState);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.OnStateUpdate();
    }

    //Use to change states
    public void ChangeCurrentState(State newState)
    {
        if(currentState != null)
        {
            currentState.OnStateExit();
        }

        currentState = newState;
        currentState.OnStateEnter(this, anim, attackRaycasts);
    }

    public void StartAnimation()
    {
        currentState.SetStartAnimation();
    }

    public void EndAnimation()
    {
        currentState.SetEndAnimation();
    }
}
