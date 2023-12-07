using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script to start raycasts on weapons
public class AttackRaycasts : MonoBehaviour
{
    public LayerMask layerMask;
    public Transform[] rayCastObjTransforms;
    private Vector3[] lastPositions;

    private bool fireRaycasts = false;

    private double damage;
    private int knockBack;

    void FixedUpdate()
    {
        if(fireRaycasts)
        {
            for(int i = 0; i < rayCastObjTransforms.Length; i++)
            {
                Transform raycastObjTransform = rayCastObjTransforms[i];

                Vector3 raycastDirection = lastPositions[i] - raycastObjTransform.position;

                Ray raycast = new Ray(raycastObjTransform.position, raycastDirection.normalized);

                RaycastHit[] hitData = Physics.RaycastAll(raycast, raycastDirection.magnitude, layerMask);
                HandleRaycastHit(hitData, raycastObjTransform);

                Debug.DrawRay(raycastObjTransform.position, raycastDirection, Color.blue);

                lastPositions[i] = raycastObjTransform.position;    
            }
        }
    }

    //use for animation events to start raycasts on weapons
    public void StartRaycasts(int kB)
    {
        knockBack = kB;
        lastPositions = new Vector3[rayCastObjTransforms.Length];
        for (int i = 0; i < rayCastObjTransforms.Length; i++)
        {
            lastPositions[i] = rayCastObjTransforms[i].position;
        }
        fireRaycasts = true;
    }

    //use for animation events to end raycasts on weapons
    public void EndRaycasts()
    {
        fireRaycasts = false;
    }

    private void HandleRaycastHit(RaycastHit[] raycastHitArr, Transform caster)
    {
        foreach (RaycastHit hitObj in raycastHitArr)
        {
            GameObject enemy = hitObj.transform.gameObject;
            Animator enemyAnimator = enemy.GetComponent<Animator>();

            if(!enemyAnimator.GetBool("isDamaged"))
            {
                Debug.Log(enemy.name + " was hit by " + caster.name);
                enemyAnimator.SetBool("isDamaged", true);
            }

            enemy.GetComponent<Rigidbody>().AddForce(transform.forward * knockBack, ForceMode.Impulse);

        }
    }
}

