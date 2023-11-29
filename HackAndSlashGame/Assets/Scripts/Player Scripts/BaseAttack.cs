using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseAttack : State
{
    protected bool shouldCombo = false; //checks if the state will be change to next move in the combo set

    public override void OnEnter()
    {
        animator.SetBool("canMove", false);
        animator.SetBool("isAttacking", true);
    }
    public override void OnUpdate()
    {
        if(Input.GetMouseButtonDown(0))
        {
            shouldCombo = true;
        }


    }

}
