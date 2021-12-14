using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCoffee : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "COFFEE")
        {
            Destroy(other.gameObject);
        }
    }


}
