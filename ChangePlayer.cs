using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayer : MonoBehaviour
{
    public int i;
    public GameObject player1, player2;
    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.FindWithTag("Player1");
        player2 = GameObject.FindWithTag("Player2");
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            i++;
        }

        if ((i % 2)== 1)
        {
            Debug.Log("Select player1");
            player1.GetComponent<PlayerMovement>().enabled = true;
            player2.GetComponent<PlayerMovement>().enabled = false;
        }
        if ((i % 2) == 0)
        {
            Debug.Log("Select player2");
            player1.GetComponent<PlayerMovement>().enabled = false;
            player2.GetComponent<PlayerMovement>().enabled = true;
        }
    }
}
