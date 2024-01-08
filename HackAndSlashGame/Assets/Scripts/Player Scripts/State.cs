using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    //on classes and derived classes can use this variable
    protected static StateController stateController;
    protected static Animator animator;
    protected static Camera camera;

    //use to get time since state switch in different updates
    protected float fixedTime;
    protected float time;
    protected State nextState;

    public static void SetVariables(Animator anim, Camera cam, StateController sc)
    {
        animator = anim;
        stateController = sc;
        camera = cam;
    }

    //inherited classes won't be able to override this method
    //use for what I want inherited all classes to have
    public void OnStateEnter()
    {
        OnEnter();
    }

    //virtual keyword allows for inherited classes to overide the method
    public virtual void OnEnter() { /*use for inherited classes*/ }

    public void OnStateUpdate() 
    {
        time += Time.deltaTime;
        OnUpdate(); 
    }

    public virtual void OnUpdate() {  }

    public void OnStateFixedUpdate() 
    { 
        fixedTime += Time.deltaTime;
        OnFixedUpdate();  
    }

    public virtual void OnFixedUpdate() { }

    public void OnStateExit() { OnExit(); }

    public virtual void OnExit() { }

    protected State ListenForAttackInputs()
    {
        if (Input.GetMouseButtonDown(0))
        {
            return new LightAttack1State();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            //get parry state
            return new ParryState();
        }

        return null;
    }

    protected State ListenForMovement()
    {
        float vertInput = Input.GetAxisRaw("Vertical");
        float horizInput = Input.GetAxisRaw("Horizontal");
        Vector3 inputMag = new Vector3(vertInput, 0, horizInput).normalized;

        if (inputMag.magnitude >= 0.001)
        {
           return new WalkState();
        }

        return null;
    }
}
