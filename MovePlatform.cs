﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{



    [SerializeField]
    float speed;

    [SerializeField]
    Transform startPoint, endPoint;

    [SerializeField]
    float changeDirectionDelay;

    private Transform destinationTarget, departTarget;

    private float startTime;
    private float journeyLength;

    bool isWaiting;

    //public Vector3 offset_left, offset_right; // adjust this on the inspector


    //public Vector3 startPoint, endPoint;


    // Start is called before the first frame update
    void Start()
    {

        
        departTarget = startPoint;
        destinationTarget = endPoint;

       // startPoint.position = transform.position + offset_left;
       // endPoint.position = transform.position + offset_right;


        Debug.Log(departTarget.position.x);

        startTime = Time.time;
        journeyLength = Vector3.Distance(departTarget.position, destinationTarget.position);  

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        
    }

    private void Move()
    {
        if (!isWaiting)
        {
            if (Vector3.Distance(transform.position, destinationTarget.position) > 0.01f)
            {
                float distCovered = (Time.time - startTime) * speed;

                float fractionOfJourney = distCovered / journeyLength;
                transform.position = Vector3.Lerp(departTarget.position, destinationTarget.position, fractionOfJourney);

            }
            else
            {
                isWaiting = true;
                StartCoroutine(changeDelay());
            }

        }
        
        
    }

    void ChangeDestination()
    {
        if(departTarget == endPoint && destinationTarget == startPoint)
        {
            departTarget = startPoint;
            destinationTarget = endPoint;
        }
        else
        {
            departTarget = endPoint;
            destinationTarget = startPoint;
        }
    }

    IEnumerator changeDelay()
    {
        yield return new WaitForSeconds(changeDirectionDelay);
        ChangeDestination();
        startTime = Time.time;
        journeyLength = Vector3.Distance(departTarget.position, destinationTarget.position);
        isWaiting = false;

    }

}
