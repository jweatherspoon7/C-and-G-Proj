using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTargeting : MonoBehaviour
{
    public Transform playerTransform;

    private Vector3 playerRay;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        playerRay = playerTransform.position - transform.position;
        Debug.DrawLine(transform.position, playerTransform.position, Color.black);
    }

    public Vector3 GetPlayerRay() { return playerRay; }

    public Transform GetPlayerTransform() { return playerTransform; }
}
