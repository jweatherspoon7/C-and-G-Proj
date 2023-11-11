using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    //on classes and derived classes can use this variable
    protected StateController stateController;
    protected Animator animator;
    protected float fixedTime;

    //inherited classes won't be able to override this method
    //use for what I want inherited all classes to have
    public void OnStateEnter(StateController sc, Animator anim)
    {
        animator = anim;
        stateController = sc;
        OnEnter();
    }

    //virtual keyword allows for inherited classes to overide the method
    public virtual void OnEnter() {/*use for inherited classes*/ }

    public void OnStateUpdate() { OnUpdate(); }

    public virtual void OnUpdate() { }

    public void OnStateFixedUpdate() 
    { 
        fixedTime = Time.deltaTime;
        OnFixedUpdate();  
    }

    public virtual void OnFixedUpdate() { }

    public void OnStateExit() { OnExit(); }

    public virtual void OnExit() { }
}
