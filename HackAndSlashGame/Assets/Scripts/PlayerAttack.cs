using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator playerAnim;
    private float attackCooldown = 0.3f;
    private float comboTimeInterval = 1;
    private string lastAttackAnim;
    private float mouseButton0DownTime; //use to differentiate a click or hold on left mouse button
    public int maxNumOfClicks = 2;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        OnClickAttack();
        Debug.Log(playerAnim.GetCurrentAnimatorClipInfo(0)[0].clip.name);
        Debug.Log("click num" + playerAnim.GetInteger("numOfClicks"));

        if (playerAnim.GetNextAnimatorStateInfo(0).IsTag("attackAnim") &&
                playerAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >= comboTimeInterval)
        {
            playerAnim.SetInteger("numOfClicks", 0);
            playerAnim.SetBool("canMove", true);
            //Debug.Log("time " + playerAnim.GetCurrentAnimatorStateInfo(0).normalizedTime);
        }

        /*
        if(Input.GetMouseButtonDown(0))
        {
            playerAnim.SetInteger("numOfClicks", 1);
            playerAnim.SetBool("canMove", false);
        }
        if(playerAnim.GetCurrentAnimatorStateInfo(0).IsName("LightAttack1"))
        {
            playerAnim.SetInteger("numOfClicks", 0);
            playerAnim.SetBool("canMove", true);
        }
        */
    }

    void OnClickAttack()
    {

        if(Input.GetMouseButtonDown(0))
        {
            mouseButton0DownTime = Time.time;
        }

        if(Input.GetMouseButtonUp(0))
        {
            //use to tell if player is clicking or holding
            float mouse0Time = Time.time - mouseButton0DownTime;
            int numOfClicks = Mathf.Clamp(playerAnim.GetInteger("numOfClicks") + 1,0,maxNumOfClicks);
            //Debug.Log(numOfClicks);

            if(numOfClicks == 1 && playerAnim.GetBool("canAttack"))
            {
                playerAnim.SetInteger("numOfClicks", numOfClicks);
                playerAnim.SetBool("canMove", false);
            }
            else if(playerAnim.GetNextAnimatorStateInfo(0).IsTag("attackAnim") && 
                playerAnim.GetCurrentAnimatorStateInfo(0).normalizedTime < comboTimeInterval)
            {
                Debug.Log("Anim 2");
                playerAnim.SetInteger("numOfClicks", numOfClicks);
            }

            //need to fix
            /*
            if(playerAnim.GetInteger("numOfClicks") == maxNumOfClicks)
            {
                playerAnim.SetInteger("numOfClicks", 0);
                playerAnim.SetBool("canMove", true);
            }
            */
        }
    }
}
    