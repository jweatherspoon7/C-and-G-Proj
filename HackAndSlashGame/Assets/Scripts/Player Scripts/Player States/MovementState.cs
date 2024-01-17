using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementState : State
{
    private float turnSmoothTime = 0.05f;
    private float turnSmoothVelocity;
    private Transform transform;
    private Transform camTransform;
    private PlayerMovementBvhr behavior;

    //use override keyword to override methods of base class
    public override void OnEnter()
    {
        animator.SetBool("canMove", true);
        animator.SetBool("isAttacking", false);
        animator.SetBool("attack1Bool", false);
        animator.SetBool("attack2Bool", false);
        animator.SetBool("attack3Bool", false);

        camTransform = camera.transform;
        transform = animator.transform;
        behavior = animator.GetBehaviour<PlayerMovementBvhr>();
    }

    public override void OnUpdate()
    {
        float horizInput = Input.GetAxisRaw("Horizontal");
        float vertInput = Input.GetAxisRaw("Vertical");

        nextState = ListenForAttackInputs(true);

        if(behavior.inUpdate)
        {
            if(animator.GetBool("isLockOn")) LockOnMovement(horizInput, vertInput);
            else FreeLookMovement(horizInput, vertInput);

            stateController.ChangeState(nextState);
        }
    }

    private void FreeLookMovement(float horizInput, float vertInput)
    {

        animator.SetFloat("horizAxis", 0);
        Vector3 direction = new Vector3(vertInput, 0, horizInput).normalized;

        if (direction.magnitude >= 0.01)
        {
            //get the desired angle relative to the camera position
            float targetAngle = (Mathf.Atan2(horizInput, vertInput) * Mathf.Rad2Deg) + camTransform.eulerAngles.y;

            //Smooths the player angle over time. 
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            //set player rotation
            transform.rotation = Quaternion.Euler(0, angle, 0);

            //move player forward
            animator.SetFloat("vertAxis", 1);
        }
        else
        {
            animator.SetFloat("vertAxis", 0);
        }
    }

    private void LockOnMovement(float horizInput, float vertInput)
    {
        Vector3 direction = new Vector3(vertInput, 0, horizInput).normalized;

        if (direction.magnitude >= 0.01)
        {
            animator.SetFloat("horizAxis", horizInput);
            animator.SetFloat("vertAxis", vertInput);
        }
        else
        {
            animator.SetFloat("horizAxis", 0);
            animator.SetFloat("vertAxis", 0);
        }
    }
}
