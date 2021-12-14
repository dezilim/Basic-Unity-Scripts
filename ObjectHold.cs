using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHold : MonoBehaviour
{
    public GameObject grabbedObj;
    public AudioSource thudSound, paperSound;
    public bool beingCarried;

    void Awake()
    {
        beingCarried = false;
        grabbedObj = transform.root.gameObject;
    }

    // other refers to player
    void OnTriggerStay(Collider parent)
    {
        // get your own parent (coffee2) 
        
        if (parent.tag == "Player1")
        {    //(Input.GetMouseButton(0))
            if ((Input.GetMouseButton(0)) && !beingCarried && (PlayerMovement.objNb == 0))
            {
                // grab coffee sound
                if (grabbedObj.tag == "COFFEE" || grabbedObj.tag == "BOX")
                {
                    thudSound.Play();
                }
                if (grabbedObj.tag == "NEWS")
                {
                    paperSound.Play();
                }
                grabbedObj.transform.SetParent(parent.transform);
                //grabbedObj.transform.position = transform.position + (grabbedObj.transform.position - transform.position) / (Vector3.Distance(grabbedObj.transform.position, transform.position));
                grabbedObj.transform.position = parent.transform.position - 1.4f*parent.transform.right;
                grabbedObj.GetComponent<Rigidbody>().isKinematic = true;
                grabbedObj.GetComponent<Rigidbody>().useGravity = false;
                beingCarried = true;
                PlayerMovement.objNb += 1;
            }
           
        }
    }


    void Update()
    {

        GameObject parent = transform.root.gameObject;
        if (beingCarried && ((Input.GetButtonDown("Fire2")) || (Vector3.Distance(grabbedObj.transform.position, parent.transform.position) > 1.5f)))
        {

            if (grabbedObj.tag == "COFFEE" || grabbedObj.tag == "BOX")
            {
                thudSound.Play();
            }
            if (grabbedObj.tag == "NEWS")
            {
                paperSound.Play();
            }
            //parent.transform.DetachChildren();
            grabbedObj.transform.parent = null;
            grabbedObj.transform.GetComponent<Rigidbody>().isKinematic = false;
            grabbedObj.transform.GetComponent<Rigidbody>().useGravity = true;
            beingCarried = false;
            PlayerMovement.objNb -= 1;

        }


    }
}
