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
        Vector3 directionToTarget = transform.position - enemy.position;
        float angle = Vector3.Angle(transform.forward, directionToTarget);

        if(Mathf.Abs(angle) > 90 && anim.GetBehaviour<ParryStateBvhr>().inSubState)
        {
            //impact
            Debug.Log("Parried attack");
        }
        else
        {
            Debug.Log("Player was hit");
            anim.SetTrigger("damageTrig");
        }
    }

    public State GetCurrentState() { return currentState; }
}
