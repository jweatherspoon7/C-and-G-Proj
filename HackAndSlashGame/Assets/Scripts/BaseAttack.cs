using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseAttack : State
{
    //bool to check if next attack should play
    protected bool shouldCombo = false;

    public override void OnEnter()
    {
        animator.SetBool("canMove", false);
        animator.SetBool("isAttacking", true);
    }
    public override void OnUpdate()
    {
        if(Input.GetMouseButtonUp(0))
        {
            shouldCombo = true;
        }
    }

    public override void OnExit()
    {
        animator.SetBool("canMove", true);
        animator.SetBool("isAttacking", false);
    }
}
