using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTargeting : MonoBehaviour
{
    public Transform playerTransform;
    private Vector3 playerRay;
    private bool canRotate;
    private bool startCooldown;

    private float turnSmoothTime = 0.5f;
    private float turnSmoothVelocity;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //move later
        if(startCooldown)
        {
            StartCoroutine(CooldownTime());
        }

        //find a the player position from the enemy
        playerRay = playerTransform.position - transform.position;
        Debug.DrawLine(transform.position, playerTransform.position, Color.black);

        float targetAngle = Quaternion.LookRotation(playerRay.normalized).eulerAngles.y;

        //Smooths the player angle over time. 
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

        transform.rotation = Quaternion.Euler(0, angle, 0);
    }

    public Vector3 GetPlayerRay() { return playerRay; }

    public Transform GetPlayerTransform() { return playerTransform; }

    public bool GetCanRotate() {  return canRotate; }

    public void SetCanRotate(bool cR) {  canRotate = cR; }

    public void StartCooldown() { startCooldown = true; }

    //move later
    IEnumerator CooldownTime()
    {
        yield return new WaitForSeconds(Random.Range(2, 3));
        animator.SetBool("onCooldown", false);
        startCooldown = false;
    }
}
