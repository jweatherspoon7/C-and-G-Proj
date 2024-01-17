using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JonathanController : MonoBehaviour
{
    public Transform playerTransform;
    private Vector3 playerRay;

    private float turnSmoothTime = 0.01f;
    private float turnSmoothVelocity;
    private bool turnEnabled = true;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Combo1Trig");
        }

        //find a the player position from the enemy
        playerRay = playerTransform.position - transform.position;

        float targetAngle = Quaternion.LookRotation(playerRay.normalized).eulerAngles.y;

        //Smooths the player angle over time. 
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

        if(turnEnabled) transform.rotation = Quaternion.Euler(0, angle, 0);
    }

    public void RegisterHit(int damage) 
    {
        Debug.Log("Boss was hit");
    }

    public Vector3 GetPlayerRay() { return playerRay; }

    public void StartCooldown(float time) { StartCoroutine(CooldownTime(time)); }

    public void SetTurnEnabled(bool  enabled) { turnEnabled = enabled; }

    public bool GetTurnEnabled() { return turnEnabled; }

    //Method to reset jonathan to look at the player
    public void ResetHeading()
    {
        float angle = Quaternion.LookRotation(playerRay.normalized).eulerAngles.y;
        transform.rotation = Quaternion.Euler(0, angle, 0);
    }

    IEnumerator CooldownTime(float time)
    {
        yield return new WaitForSeconds(time);
        animator.SetBool("OnCooldown", false);
    }
}
