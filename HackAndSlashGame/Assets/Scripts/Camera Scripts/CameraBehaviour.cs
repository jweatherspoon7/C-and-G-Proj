using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Transform lockOnCamTransform;
    public Transform enemy;

    public float cameraSlack, camDistance = 1;
    private Vector3 lockOnCamOffset;

    // Start is called before the first frame update
    void Start()
    {
        lockOnCamOffset = lockOnCamTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        LockOnCamFollow();
    }

    private void LockOnCamFollow()
    {

        lockOnCamTransform.position = transform.position - lockOnCamOffset;
        //lockOnCamTransform.position -= lockOnCamTransform.forward * lockOnCamOffset.magnitude;
    }
}
