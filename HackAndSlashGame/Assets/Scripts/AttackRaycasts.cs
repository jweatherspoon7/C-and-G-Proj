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

    //Keeps track of objects hit to make sure they are not hit multiple times in one attack
    private List<int> hitList = new List<int>();

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

                if(hitData.Length > 0) 
                {
                    HandleRaycastHit(hitData, raycastObjTransform);
                }

                Debug.DrawRay(raycastObjTransform.position, raycastDirection, Color.blue);

                lastPositions[i] = raycastObjTransform.position;    
            }
        }
    }

    //use for animation events to start raycasts on weapons
    public void StartRaycasts(int kB)
    {
        knockBack = 0;
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
        hitList.Clear();
    }

    private void HandleRaycastHit(RaycastHit[] raycastHitArr, Transform caster)
    {
        foreach (RaycastHit hitObj in raycastHitArr)
        {
            bool inHitList = false;

            GameObject obj = hitObj.transform.gameObject;
            Animator objAnimator = obj.GetComponent<Animator>();

            foreach (int hash in hitList)
            {
                if(obj.GetHashCode() == hash)
                {
                    inHitList = true;
                    break;
                }
            }

            if (inHitList) continue;
            else hitList.Add(obj.GetHashCode());


            if (obj.tag.Equals("Player"))
            {
                obj.GetComponent<StateController>().RegisterHit(transform);
            }
            else
            {
                Debug.Log(obj.tag);
                objAnimator.SetTrigger("damageTrig");
            }

            obj.GetComponent<Rigidbody>().AddForce(transform.forward * knockBack, ForceMode.Impulse);

        }
    }
}

