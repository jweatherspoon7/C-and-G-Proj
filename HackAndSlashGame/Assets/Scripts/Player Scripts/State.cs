using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    //on classes and derived classes can use this variable
    protected static StateController stateController;
    protected static Animator animator;

    //use to get time since state switch in different updates
    protected float fixedTime;
    protected float time;

    public static void SetVariables(Animator anim, StateController sc)
    {
        animator = anim;
        stateController = sc;
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

    public virtual void OnUpdate() { }

    public void OnStateFixedUpdate() 
    { 
        fixedTime += Time.deltaTime;
        OnFixedUpdate();  
    }

    public virtual void OnFixedUpdate() { }

    public void OnStateExit() { OnExit(); }

    public virtual void OnExit() { }
}
