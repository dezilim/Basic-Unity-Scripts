using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    public Vector3 offset;
    public GameObject grabbedObj;
    public GameObject player;

    public float distToGround = 2.2f;
    public float distToCatcher = 0.5f;
    public float distToObject = 1f;

    private float jumpSpeed = 300f;
    private float moveSpeed = 500f;

    public float yAngle;
    public Vector3 direction;
    public bool isGrounded;
    public bool localTouchedCatcher;

    public bool carryObject;
    public bool isThrowable;
    public bool objInRegion;
    public float throwForce = 1f;

    public static int objNb;
    public static bool AIisSleeping;

    public ParticleSystem ash;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //offset = Vector3.up;
        //touchedCatcher = false;
        objNb = 0;
        //AIisSleeping = false;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, distToGround);
        float horizontalInput = Input.GetAxis("Horizontal");
        float forwardInput = Input.GetAxis("Vertical");


        Debug.Log("ObjNb : "+ objNb);

        // Jump
        if (Input.GetButtonDown("Jump") && isGrounded)// && transform.position.y < 1.5)
        {
            Debug.Log("Jump pressed");
            rb.velocity = Vector3.up * jumpSpeed * Time.deltaTime; // using velocity makes it better
        }

        // move left right forward backward
        rb.velocity = new Vector3(moveSpeed * horizontalInput * Time.deltaTime, rb.velocity.y, moveSpeed * forwardInput * Time.deltaTime);
        direction = rb.velocity.normalized;
        yAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + 90f;

        // UPDATE THE ROTATION WHENEVER USER INPUT (SMOOTH ROTATION)
        if (Mathf.Abs(rb.velocity.x) > 0 || Mathf.Abs(rb.velocity.z) > 0)
        {
            transform.localEulerAngles = new Vector3(0f, yAngle, 0f);
        }



        // check if near another player 
        //RaycastHit hit;
        //if (Physics.SphereCast(transform.position, 1f, Vector3.forward, out hit))
        //{
        //    Debug.Log("There is something");
        //    if (hit.collider.gameObject.tag == "Object" )
        //    {
        //        //hit.collider.gameObject.GetComponent<TouchedCatcher>().enabled = false;
        //        Debug.Log("object detected");
        //        grabbedObj = hit.collider.gameObject;
        //        //grabbedObj.transform.SetParent(this.transform);
        //        player.AddComponent<FixedJoint>();
        //        player.GetComponent<FixedJoint>().connectedBody = grabbedObj.GetComponent<Rigidbody>();
        //        //grabbedObj.GetComponent<Rigidbody>().velocity = 10 * (transform.position - grabbedObj.transform.position);

        //    }
        //}
        //RaycastHit hit;

        //if (Physics.SphereCast(transform.position, 2f, Vector3.right, out hit, distToObject))
        //{
        //    if (hit.collider.gameObject.tag == "Object")
        //    {

        //        Debug.Log("Object detected");
        //        grabbedObj = hit.collider.gameObject;
        //        // pick up the object
        //        if (Input.GetKeyDown(KeyCode.E))
        //        {
        //            Debug.Log("E pressed");
        //            carryObject = true;
        //            isThrowable = true;
        //            if (carryObject)
        //            {
        //                //
        //                grabbedObj.transform.SetParent(this.transform);
        //                grabbedObj.transform.position = transform.position;
        //                grabbedObj.GetComponent<Rigidbody>().isKinematic = true;
        //                grabbedObj.GetComponent<Rigidbody>().useGravity = false;
        //                //currObject.gameObject.transform.position = transform.position;
        //            }
        //        }
        //        if (Input.GetMouseButton(1))
        //        {
        //            carryObject = false;
        //            isThrowable = false;
        //        }
        //        if (!carryObject)
        //        {
        //            this.transform.DetachChildren();
        //            grabbedObj.transform.GetComponent<Rigidbody>().isKinematic = false;
        //            grabbedObj.transform.GetComponent<Rigidbody>().useGravity = true;
        //        }
        //        if (Input.GetMouseButton(0))
        //        {
        //            if (isThrowable)
        //            {
        //                this.transform.DetachChildren();
        //                grabbedObj.transform.GetComponent<Rigidbody>().isKinematic = false;
        //                grabbedObj.transform.GetComponent<Rigidbody>().useGravity = true;
        //                grabbedObj.transform.GetComponent<Rigidbody>().AddRelativeForce(transform.forward * throwForce);
        //            }
        //        }


        //    }
        //}

        //---------------------
        // HELLLLLLPPPPPPPPPPP
        // send raycast at every frame and check if object is in region 
        //RaycastHit hit;
        ////objInRegion = (Physics.SphereCast(transform.position, 1f, Vector3.right, out hit, distToObject) || Physics.SphereCast(transform.position, 1f, Vector3.left, out hit, distToObject) || Physics.SphereCast(transform.position, 1f, Vector3.forward, out hit, distToObject) || Physics.SphereCast(transform.position, 1f, Vector3.back, out hit, distToObject)) ;
        //objInRegion = Physics.Raycast(transform.position, Vector3.forward, out hit, distToObject);
        //Debug.Log(objInRegion);

        //if (objInRegion)
        //{
        //    if (hit.collider.gameObject.tag == "Object")
        //    {
        //        Debug.Log("Object detected");
        //        grabbedObj = hit.collider.gameObject;
        //    }

        //}


        //// pick object up. grabbedObj is defined since objInRegion
        //// can only carry if you are not carrying another object
        //if (Input.GetKeyDown(KeyCode.E) && objInRegion && !carryObject)
        //{
        //    Debug.Log("E pressed");
        //    grabbedObj.transform.SetParent(this.transform);

        //    grabbedObj.transform.position = transform.position + (grabbedObj.transform.position - transform.position)/(Vector3.Distance(grabbedObj.transform.position, transform.position));
        //    grabbedObj.GetComponent<Rigidbody>().isKinematic = true;
        //    grabbedObj.GetComponent<Rigidbody>().useGravity = false;

        //    carryObject = true;
        //    isThrowable = true;
        //}

        //if (Input.GetMouseButton(0) && isThrowable)
        //{
        //    this.transform.DetachChildren();
        //    grabbedObj.transform.GetComponent<Rigidbody>().isKinematic = false;
        //    grabbedObj.transform.GetComponent<Rigidbody>().useGravity = true;
        //    grabbedObj.transform.GetComponent<Rigidbody>().AddRelativeForce(transform.forward * throwForce);

        //    carryObject = false;
        //    isThrowable = false;
        //}

        //------------

        //RaycastHit hit;
        //if (Physics.Raycast(transform.position, Vector3.up, out hit, distToCatcher))
        //{
        //  Debug.Log("There is something");
        //if (hit.collider.gameObject.tag == "CatcherTrigger")
        //{
        //   Debug.Log("Touched");
        // touchedCatcher = true;
        //transform.position = hit.collider.gameObject.transform.position - offset;
        //rb.velocity = new Vector3(0, 0, 0);
        //rb.useGravity = false;
        // }
        //}

        //if (touchedCatcher)
        //{
        //    transform.position = GameObject.FindWithTag("CatcherTrigger").transform.position - offset;
        //}

        // pick up object
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    Debug.Log("E pressed");

        //    //Ray directionRay = new Ray(transform.position, transform.forward);
        //    if (Physics.SphereCast(transform.position, 3f, Vector3.right, out hit, distToObject))
        //    {
        //        if (hit.collider.gameObject.tag == "Object")
        //        {
        //            Debug.Log("Object detected");
        //            carryObject = true;
        //            isThrowable = true;
        //            if (carryObject)
        //            {
        //                //grabbedObj = hit.collider.gameObject;
        //                hit.collider.gameObject.transform.SetParent(this.transform);
        //                hit.collider.gameObject.transform.position = transform.position;
        //                hit.collider.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        //                hit.collider.gameObject.GetComponent<Rigidbody>().useGravity = false;
        //                //currObject.gameObject.transform.position = transform.position;
        //            }
        //        }
        //    }
        //}
        //if (Input.GetMouseButton(1))
        //{
        //    carryObject = false;
        //    isThrowable = false;
        //}
        //if (!carryObject)
        //{
        //    this.transform.DetachChildren();
        //    hit.collider.gameObject.transform.GetComponent<Rigidbody>().isKinematic = false;
        //    hit.collider.gameObject.transform.GetComponent<Rigidbody>().useGravity = true;
        //}
        //if (Input.GetMouseButton(0))
        //{
        //    if (isThrowable)
        //    {
        //        this.transform.DetachChildren();
        //        hit.collider.gameObject.transform.GetComponent<Rigidbody>().isKinematic = false;
        //        hit.collider.gameObject.transform.GetComponent<Rigidbody>().useGravity = true;
        //        hit.collider.gameObject.transform.GetComponent<Rigidbody>().AddRelativeForce(transform.forward * throwForce);
        //    }
        //}
        //void OnTriggerStay(Collider other)
        //{
        //    if (Input.GetKeyDown(KeyCode.E) && other.gameObject.tag == "Object")
        //    {
        //        Debug.Log("Object detected");
        //    }
        //}


    }
}
