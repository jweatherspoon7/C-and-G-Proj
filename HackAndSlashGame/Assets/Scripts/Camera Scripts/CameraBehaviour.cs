using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Camera cam;
    //cm is cinemachine
    public CinemachineTargetGroup cmLockonGroup;

    public float locateRadius;

    public float playerRadius = 8;
    public float playerWeight = 1;

    public float targetRadius = 0;
    public float targetWeight = 2;

    public LayerMask targetLayerMask;

    private Animator animator;
    private CinemachineTargetGroup.Target playerTarget;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerTarget = new CinemachineTargetGroup.Target { target = transform, radius = playerRadius, weight = playerWeight};
    }

    // Update is called once per frame
    void Update()
    {
        //lock on if middle mouse button is clicked
        if (Input.GetMouseButtonDown(2))
        {
           if(!animator.GetBool("isLockOn"))
           {
                LocateTarget();
           }
           
            animator.SetBool("isLockOn", !animator.GetBool("isLockOn"));
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, locateRadius);
    }

    private void LocateTarget()
    {
        List<Transform> possibleTargets = FindPossibleTargets();
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
        SetCinemachineTargets(target);
    }

    private List<Transform> FindPossibleTargets()
    {
        List<Transform> possibleTargets = new List<Transform>();

        //find all enemy colliders in the radius
        Collider[] colliders = Physics.OverlapSphere(transform.position, locateRadius, targetLayerMask);
        possibleTargets.Add(colliders[0].transform.root);

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

    private void SetCinemachineTargets(Transform target)
    {
        CinemachineTargetGroup.Target[] targetGroup = new CinemachineTargetGroup.Target[2];

        targetGroup[0] = playerTarget;
        targetGroup[1] = new CinemachineTargetGroup.Target { target = target, radius = targetRadius, weight = targetWeight};
        cmLockonGroup.m_Targets = targetGroup;
    }

    private void ResetCinemachineTargets()
    {
        cmLockonGroup.m_Targets = null;
    }
}
