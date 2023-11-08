using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator playerAnim;
    private float attackCooldown = 0.3f;
    private float startTime;
    private int numOfClicks = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            numOfClicks++;
            numOfClicks = Mathf.Clamp(numOfClicks, 0, 3);
            Debug.Log(numOfClicks);

            startTime = Time.time;
            playerAnim.SetInteger("numOfClicks", 1);
            playerAnim.SetBool("canMove", false);
        }

        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Click Time: " + (Time.time - startTime));
        }

        if(playerAnim.GetCurrentAnimatorStateInfo(0).IsName("LightAttack1"))
        {
            playerAnim.SetInteger("numOfClicks", 0);
            playerAnim.SetBool("canMove", true);
        }
    }

    void OnClick()
    {
       numOfClicks = Mathf.Clamp(numOfClicks, 0,3);

    }
}
    