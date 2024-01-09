using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateController : MonoBehaviour
{
    State currentState;
    Animator anim;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        State.SetVariables(anim, cam, this);
        ChangeState(new IdleState());
    }

    // Update is called once per frame
    void Update()
    {
        currentState.OnStateUpdate();
    }

    public void ChangeState(State newState)
    {
        if(newState == null) { return; }

        if (currentState != null)
        {
            currentState.OnStateExit();
        }

        currentState = newState;
        currentState.OnStateEnter();
    }

    //add damage knockback other effects in param
    public void RegisterHit(Transform enemy)
    {
        Vector3 directionToTarget = enemy.position - transform.position;
        float angle = Vector3.Angle(transform.forward, directionToTarget);

        //if enemy is in front of play when parring
        if(angle <= 60 && anim.GetBehaviour<ParryStateBvhr>().inSubState)
        {
            Debug.Log("Parried attack " + angle);
        }
        else
        {
            anim.SetTrigger("damageTrig");
        }
    }

    public State GetCurrentState() { return currentState; }
}
