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
        Debug.Log("BaseAttack enter");
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
