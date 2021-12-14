using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldObject : MonoBehaviour
{

    bool jointed;
    // Start is called before the first frame update

    void start()
    {
        jointed = false;
    }
    void OnTriggerStay(Collider other)
    {
        // other is the player 
        Debug.Log("Object touched player");
        if (other.gameObject.tag == "Player1" || other.gameObject.tag == "Player2")
        {
            if (Input.GetButtonDown("Fire2") && !jointed)
            {
                Debug.Log("Attach to player");
                gameObject.AddComponent<FixedJoint>();
                gameObject.GetComponent<FixedJoint>().connectedBody = other.gameObject.GetComponent<Rigidbody>();
                jointed = true;
            }
            //if (Input.GetButtonDown("Fire2") && jointed)
            //{
            //    Debug.Log("Remove from player");
            //    Destroy(GetComponent<FixedJoint>());
            //    jointed = false;
            //}
        }
            
    }

}
