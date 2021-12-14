using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndOfBelt : MonoBehaviour
{
    public AudioSource acceptNews;
    public Text sent;
    public float timer;

    void Start()
    {
        timer = 0;
    }
    void Update()
    {
        if (sent.enabled)
        {
            timer += Time.deltaTime;
        }

        if (Mathf.Round(timer) == 1f)
        {
            sent.enabled = false;
            timer = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "NEWS")
        {
            TextManager.newsPaperNb += 1;
            Debug.Log("News Received");
            sent.enabled = true;
            acceptNews.Play();
            Destroy(other.gameObject);

        }

        if (other.tag == "COFFEE")
        {
            Destroy(other.gameObject);
        }
    }
}
