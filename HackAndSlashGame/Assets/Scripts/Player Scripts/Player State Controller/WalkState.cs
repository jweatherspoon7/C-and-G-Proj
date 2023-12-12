using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WalkState : State
{
    private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    private Transform transform;
    private Transform camTransform;
    private WalkStateBhvr behaviour;

    public override void OnEnter()
    {
        Debug.Log("Walk");
        camTransform = camera.transform;
        transform = animator.transform;
        behaviour = animator.GetBehaviour<WalkStateBhvr>();

        animator.SetBool("canMove", true);
        animator.SetBool("isAttacking", false);
        animator.SetBool("isWalking", true);
    }

    public override void OnUpdate()
    {
        if (behaviour.inUpdate)
        {
            //gets keyboard inputs
            float vertInput = Input.GetAxisRaw("Vertical");
            float horizInput = Input.GetAxisRaw("Horizontal");

            //gets desired direction of player
            Vector3 direction = new Vector3(vertInput, 0, horizInput).normalized;

            if (direction.magnitude >= 0.01)
            {
                //get the desired angle relative to the camera position
                float targetAngle = (Mathf.Atan2(horizInput, vertInput) * Mathf.Rad2Deg) + camTransform.eulerAngles.y;

                //Smooths the player angle over time. 
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

                //set player rotation
                transform.rotation = Quaternion.Euler(0, angle, 0);
            }
            else
            {
                stateController.ChangeState(new IdleState());
            }
        }
    }

    public override void OnExit()
    {
        animator.SetBool("isWalking", false);
    }
}