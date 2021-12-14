using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// render box, play coffe sound, destroy coffee, cat sound, change state of kitty cat 
public class RenderBox : MonoBehaviour
{
    public Renderer rend;
    //public Animator anim;
    //public Slider slider;
    //public AudioSource meowSound, pourCoffeeSound;
    //public ParticleSystem ash;

    void Start()
    {
        rend = GetComponent<Renderer>();
        //anim = GetComponent<Animator>();
        rend.enabled = false;
    }


    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        // if got coffee or cat detected
        // the blue detector lights up
        if ((other.tag == "COFFEE") || (other.tag == "Player1"))
        {
            rend.enabled = true;
        }

        if ((other.tag == "COFFEE") && (other.transform.parent == null))
        {
            //pourCoffeeSound.Play();
            Destroy(other.gameObject);

            //if (anim.GetBool("isSleeping"))
            //{
            //    //anim.SetBool("isSleeping", false);
            //    ash.Stop();
            //    meowSound.Play();
            //    //other.transform.parent = null;
            //    //Destroy(other);
            //    TextManager.kittiesAwakeNb += 1;
            //    //slider.value = 1;
            //}
        }
    }
    void OnTriggerExit(Collider other)
    {
        rend.enabled = false;
    }
}
