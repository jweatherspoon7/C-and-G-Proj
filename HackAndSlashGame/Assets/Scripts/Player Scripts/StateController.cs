using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//centeral player controller class
public class StateController : MonoBehaviour
{
    State currentState;
    Animator anim;
    public Camera cam;
    public LevelHandler levelHandler;

    [Header("Parry Particles")]
    public ParticleSystem parryParticle;

    [Header("Audio Clips")]
    public AudioClip parryClip;

    private AudioSource audioSource;

    private HealthBar healthBar;

    private const int MAX_HEALTH = 20;
    private int currentHealth;

    private bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        State.SetVariables(anim, cam, this);
        ChangeState(new MovementState());

        audioSource = GetComponent<AudioSource>();

        healthBar = GetComponentInChildren<HealthBar>();

        currentHealth = MAX_HEALTH;
    }

    // Update is called once per frame
    void Update()
    {
        currentState.OnStateUpdate();
    }

    public void ChangeState(State newState)
    {
        if(newState == null) return; 

        if (currentState != null)
        {
            currentState.OnStateExit();
        }

        currentState = newState;
        currentState.OnStateEnter();
    }

    //add damage knockback other effects in param
    public void RegisterHit(Transform enemy, int damage)
    {
        Vector3 directionToTarget = enemy.position - transform.position;
        float angle = Vector3.Angle(transform.forward, directionToTarget);

        //if enemy is in front of play when parring
        if(angle <= 65 && anim.GetBehaviour<ParryStateBvhr>().inSubState)
        {
            audioSource.PlayOneShot(parryClip, 0.7f);
            parryParticle.Play();
        }
        else
        {

            if (!dead)
            {
                //deal damage
                currentHealth -= damage;
                Debug.Log("health" + damage);
                healthBar.UpdateHealthBar(currentHealth, MAX_HEALTH);
                anim.SetTrigger("damageTrig");

                if (currentHealth <= 0)
                {
                    anim.SetTrigger("deathTrig");
                    //levelHandler.PlayerDeath();
                }
            }
        }
    }

    public State GetCurrentState() { return currentState; }
}
