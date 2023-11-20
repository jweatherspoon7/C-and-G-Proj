using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRaycasts : MonoBehaviour
{
    //use to get 
    public Transform[] rayCastObjTransforms;
    private Vector3[] lastPositions;

    private bool fireRaycasts = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(fireRaycasts)
        {
            for(int i = 0; i < rayCastObjTransforms.Length; i++)
            {
                Vector3 raycastDirection = lastPositions[i] - rayCastObjTransforms[i].position;

                Ray raycast = new Ray(rayCastObjTransforms[i].position, raycastDirection.normalized);

                RaycastHit[] hitData = Physics.RaycastAll(raycast, raycastDirection.magnitude);

                Debug.DrawRay(rayCastObjTransforms[i].position, raycastDirection, Color.red);

                lastPositions[i] = rayCastObjTransforms[i].position;    
            }
        }
    }

    public void StartRaycasts()
    {
        lastPositions = new Vector3[rayCastObjTransforms.Length];
        for (int i = 0; i < rayCastObjTransforms.Length; i++)
        {
            lastPositions[i] = rayCastObjTransforms[i].position;
        }
        fireRaycasts = true;
    }

    public void EndRaycasts()
    {
        fireRaycasts = true;
    }
}
