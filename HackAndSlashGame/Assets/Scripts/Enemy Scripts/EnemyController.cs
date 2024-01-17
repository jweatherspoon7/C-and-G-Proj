using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//change to enemyController later
public class EnemyController : MonoBehaviour
{

    public int maxHitPoints = 10;
    public GameObject levelHandler;

    private int hitPoints;
    public Transform playerTransform;

    private Vector3 playerRay;

    private float turnSmoothTime = 0.05f;
    private float turnSmoothVelocity;

    private Animator animator;

    private FloatingHealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        hitPoints = maxHitPoints;

        animator = GetComponent<Animator>();

        healthBar = GetComponentInChildren<FloatingHealthBar>();
    }

    // Update is called once per frame
    void Update()
    {

        //find a the player position from the enemy
        playerRay = playerTransform.position - transform.position;
        Debug.DrawLine(transform.position, playerTransform.position, Color.black);

        float targetAngle = Quaternion.LookRotation(playerRay.normalized).eulerAngles.y;

        //Smooths the player angle over time. 
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

        transform.rotation = Quaternion.Euler(0, angle, 0);

    }

    public Vector3 GetPlayerRay() { return playerRay; }

    public void RegisterHit(int damage)
    {
        animator.SetTrigger("damageTrig");
        hitPoints -= damage;
        healthBar.UpdateHealthBar(hitPoints, maxHitPoints);

        Debug.Log("Enemy has " + hitPoints + "hp");

        if (hitPoints <= 0)
        {
            Debug.Log("enemy has died!");

            animator.SetTrigger("deathTrig");
            if (levelHandler != null) levelHandler.GetComponent<LevelHandler>().KilledEnemy(gameObject);
        }
    }

    public void StartCooldown(float time) { StartCoroutine(CooldownTime(time)); }

    //move later
    IEnumerator CooldownTime(float time)
    {
        yield return new WaitForSeconds(time);

        animator.SetBool("onCooldown", false);
    }
}
