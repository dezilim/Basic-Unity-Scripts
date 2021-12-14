using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public float conveyorSpeed = 5f;
    public Transform endpoint;

    void OnTriggerStay(Collider other)
    {
        Debug.Log("Conveyor active");
        // if got parent
        if (other.transform.parent != null)
        {
            other.transform.parent.gameObject.transform.position = Vector3.MoveTowards(other.transform.parent.gameObject.transform.position, endpoint.position, conveyorSpeed * Time.deltaTime);
        }
        else
        {
            other.transform.position = Vector3.MoveTowards(other.transform.position, endpoint.position, conveyorSpeed * Time.deltaTime);
        }
        //rb = other.GetComponent<Rigidbody>();
        //rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, conveyorSpeed);
        
    }
}
