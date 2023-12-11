using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectContainerScript : MonoBehaviour
{
    public Transform cornerFront;
    public Transform cornerBack;
    private BoxCollider container;

    // Start is called before the first frame update
    void Start()
    {
        container = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
