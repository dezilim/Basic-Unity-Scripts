using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
Detects sleep or awake state of ai
Changes animation
Changes kittynb count
Manages ash particle system
Manage sleepbar
Spawns newspaper
*/
public class AIstate : MonoBehaviour
{
   
    public GameObject aiDetector, newsPaper1;
    public Renderer rend;
    public Slider slider;
    public Animator anim;
    public AudioSource meowSound, pourCoffeeSound;

    public float startTime, shift, totalSleepTime, newsStartTime, newsPaper1rot, produceNewsInTime;
    public float targetProgress;

    public bool isBurning, receivedCoffee;
    public ParticleSystem ash;

    void Start()
    {
        Random rnd = new Random();
        //rend = aiDetector.GetComponent<Renderer>();
        anim = GetComponent<Animator>();
        anim.SetBool("isSleeping", false);

        shift = Random.Range(0f, 8f);
        //totalSleepTime = 15f - shift;
        //Debug.Log("SleepTime: "+ sleepTime);
        startTime = 0;
        newsStartTime = 0;
        



    }

    void Update()
    {
        // AWAKE
        // icnrease time if awake
        if (!anim.GetBool("isSleeping"))
        {
            slider.value = (totalSleepTime - startTime) / totalSleepTime;
            startTime += Time.deltaTime;
            //Debug.Log("startTime: " + startTime);
            newsStartTime += Time.deltaTime;



            if (Mathf.Round(newsStartTime) == produceNewsInTime)
            {
                // spawn newspaper
                newsPaper1rot = Random.Range(0f, 90f);
                Vector3 position = new Vector3(Random.Range(-5f, 5f), 3f, Random.Range(-3f, -1f));
                Instantiate(newsPaper1, position, Quaternion.Euler(0f, newsPaper1rot, 0.0f));
                // reset counter for news producing
                newsStartTime = 0;
            }




        }

        // SLEEP 
        // sleep after 5 seconds. Burning. and reset timer.
        if (Mathf.Round(startTime) == totalSleepTime)
        {
            anim.SetBool("isSleeping", true);
            //isSleeping = true;
            TextManager.kittiesAwakeNb -= 1;
            isBurning = true;
            startTime = 0;
            newsStartTime = 0;

            if (isBurning)
            {
                ash.Play();
                isBurning = false;
            }
        }

    }


        // Update is called once per frame
        void OnTriggerEnter(Collider other)
        {
            // if got coffee or cat detected
            // the blue detector lights up
            //if ((other.tag == "COFFEE") || (other.tag == "Player1"))
            //{
            //    rend.enabled = true;
            //}
            // if there is coffee that is being carried
            if ((other.tag == "COFFEE") && (other.transform.parent == null))
            {
                pourCoffeeSound.Play();
                // only manage particle system and sleeping state if the cat is sleeping
                if (anim.GetBool("isSleeping"))
                {
                    anim.SetBool("isSleeping", false);
                    ash.Stop();
                    meowSound.Play();
                    //other.transform.parent = null;
                    //Destroy(other);
                    TextManager.kittiesAwakeNb += 1;
                    slider.value = 1;
                }

            }
        }


    }
