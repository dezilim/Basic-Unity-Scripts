using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchedCatcher : MonoBehaviour
{
    public Vector3 offset;
    public bool touchedCatcher;
    public Rigidbody rb;
    public float distToCatcher = 0.5f;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        touchedCatcher = false;
    }

    // Update is called once per frame
    void Update()
    {


        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.up, out hit, distToCatcher))
        {
            Debug.Log("There is something");
            if (hit.collider.gameObject.tag == "CatcherTrigger")
            {
                Debug.Log("Touched");
                touchedCatcher = true;
                //transform.position = hit.collider.gameObject.transform.position - offset;
                //rb.velocity = new Vector3(0, 0, 0);
                //rb.useGravity = false;
            }
        }

        if (touchedCatcher)
        {
            transform.position = GameObject.FindWithTag("CatcherTrigger").transform.position - offset;
        }
    }
}
