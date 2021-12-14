using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnCoffee : MonoBehaviour
{
    public GameObject coffee;
    public AudioSource pourCoffeeSound;
    public Vector3 offset;
    public float timePassed;

    public Text ready;


    void Start()
    {
        timePassed = 0;
        ready.enabled = false;
    }

    void Update()
    {
        timePassed += Time.deltaTime;
        if (Mathf.Round(timePassed) > 1f)
        {
            ready.enabled = true ;
        }
    }
    // at each click you resent timePassed to 0 and can onnly click again after 1 s
    void OnTriggerStay(Collider other)
    {
        Debug.Log("Entered coffee detector");
        if (Input.GetButtonDown("Fire1") && (Mathf.Round(timePassed) > 1f) )
        {
            timePassed = 0;
            ready.enabled = false;
            Debug.Log("Spawn coffee");
            Instantiate(coffee, new Vector3(-4.89f,1.3f,3.63f), Quaternion.Euler(0f, 0.0f,0.0f));
            pourCoffeeSound.Play();
        }
    }


}
