using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    //on classes and derived classes can use this variable
    protected StateController stateController;
    protected Animator animator;

    //inherited classes won't be able to override this method
    public void OnStateEnter(StateController sc, Animator anim) 
    {
        animator = anim;
        stateController = sc;
        OnEnter();
    }

    //virtual keyword allows for inherited classes to overide the method

    public virtual void OnEnter() { }

    public void OnStateUpdate() { }

    public virtual void OnUpdate() { }

    public void OnStateFixedUpdate() {  }

    public virtual void OnFixedUpdate() { }


    public virtual void OnStateExit() { }

    public void OnExit() { }
}
