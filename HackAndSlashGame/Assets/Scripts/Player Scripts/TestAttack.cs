using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAttack : MonoBehaviour
{

    private int i;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("MonoBehavior Update " + i);
        i++;
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Test");
        }
    }
}
