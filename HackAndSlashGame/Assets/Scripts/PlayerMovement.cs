using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody playerRb;
    public Transform camTransform;
    private float speed = 10;
    private float lastRotation = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        //freeze x and z rotation axis to stop player from tipping over
        playerRb.constraints = RigidbodyConstraints.FreezeRotationZ;
        playerRb.constraints = RigidbodyConstraints.FreezeRotationX;
    }

    // Update is called once per frame
    void Update()
    {
        //keeps player from tipping over
        transform.rotation = Quaternion.Euler(0, lastRotation, 0);

        float vertInput = Input.GetAxisRaw("Vertical");
        float horizInput = Input.GetAxisRaw("Horizontal");

        Vector3 direction = new Vector3(vertInput, 0, horizInput).normalized;

        if (direction.magnitude >= 0.01)
        {
            float targetAngle = (Mathf.Atan2(horizInput, vertInput) * Mathf.Rad2Deg) + camTransform.eulerAngles.y;

            transform.rotation = Quaternion.Euler(0, targetAngle, 0);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            lastRotation = targetAngle;
        }
    }
}
