using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attracted : MonoBehaviour
{
    //public GameObject player;
    public float force = 10000f;
    bool hasJoint;
    public Transform pos;

    void awake()
    {
        //pos.position = transform.position;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody>() != null && !hasJoint)
        {
            gameObject.AddComponent<HingeJoint>();
            gameObject.GetComponent<HingeJoint>().anchor = new Vector3(0f, 5f, 0f);
            gameObject.GetComponent<HingeJoint>().connectedBody = collision.rigidbody;
            //collision.rigidbody.useGravity = false;
            hasJoint = true;
        }
        //player.GetComponent<Rigidbody>().AddForce((transform.position - player.transform.position) * force);
        //player.GetComponent<Rigidbody>().velocity = Vector3.up * force ;
        Debug.Log("Attached");


        //Destroy(gameObject);
    }
}
