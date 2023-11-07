using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform camTransform;
    private Rigidbody playerRb;
    private Animator playerAnim;

    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    //private float speed = 10; use speed if player if moving by position instead of animation

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();

        //freeze x and z rotation axis to stop player from tipping over
        playerRb.constraints = RigidbodyConstraints.FreezeRotationZ;
        playerRb.constraints = RigidbodyConstraints.FreezeRotationX;
    }

    // Update is called once per frame
    void Update()
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

            playerAnim.SetInteger("walkSpeed", 1);
            //transform.Translate(Vector3.forward * speed * Time.deltaTime); only use when moving by position
        }
        else
        {
            playerAnim.SetInteger("walkSpeed", 0);
        }
    }
}
