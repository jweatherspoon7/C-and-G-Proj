using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Camera cam;
    //cm is cinemachine
    public CinemachineVirtualCamera virtualCamera;

    public float locateRadius;

    public LayerMask targetLayerMask;

    private Animator animator;
    private Transform currentTarget;

    // Start is called before the first frame update
    void Start()
    {
        //hide and lock cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if enemy is dead go back to free look
        if (virtualCamera.LookAt == null)
        {
            animator.SetBool("isLockOn", false);
            currentTarget = null;
        }

        //lock on if middle mouse button is clicked
        if (Input.GetMouseButtonDown(2))
        {
           if(!animator.GetBool("isLockOn"))
           {
                LocateTarget();
           }
           else currentTarget = null;
           
            animator.SetBool("isLockOn", !animator.GetBool("isLockOn"));
        }

        TrackTarget();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, locateRadius);
    }

    private void TrackTarget()
    {
        if (currentTarget == null) return;

        transform.LookAt(currentTarget);
    }

    //method to find the game object that is closest to the center of the screen to get its target
    private void LocateTarget()
    {
        List<Transform> possibleTargets = FindPossibleTargets();

        if (possibleTargets == null) return;

        Transform target = possibleTargets[0];

        Vector3 centerOfViewport = new Vector3(0.5f, 0.5f, 0);
        float shortestDist = Vector3.Distance(centerOfViewport, cam.WorldToViewportPoint(target.position));

        //if needed add distance from player
        foreach (Transform pTarget in possibleTargets)
        {
            Vector3 targetViewport = cam.WorldToViewportPoint(pTarget.position);
            targetViewport.z = 0;
            float dist = Vector3.Distance(centerOfViewport, targetViewport);

            if(dist < shortestDist)
            {
                shortestDist = dist;
                target = pTarget;
            }
        }

        currentTarget = target;
        virtualCamera.LookAt = currentTarget;
    }

    //Method to find all colliders that are within a distance from the player
    private List<Transform> FindPossibleTargets()
    {
        List<Transform> possibleTargets = new List<Transform>();

        //find all enemy colliders in the radius
        Collider[] colliders = Physics.OverlapSphere(transform.position, locateRadius, targetLayerMask);

        if (colliders.Length == 0) return null;

        //put all enemy transforms in a list
        for (int i = 0; i < colliders.Length; i++)
        {
            bool notInList = true;
            Collider targetCollider = colliders[i];
            for (int j = 0; j < possibleTargets.Count; j++)
            {
                Transform target = possibleTargets[j];

                if (targetCollider.transform.root.GetHashCode() == target.GetHashCode())
                {
                    notInList = false;
                    break;
                }
            }

            if (notInList)
            {
                possibleTargets.Add(targetCollider.transform.root);
            }
        }

        return possibleTargets;
    }
}
