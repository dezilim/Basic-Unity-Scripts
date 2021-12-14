using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level2Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject levelDescription, startButton, level2panel;
    //public GameObject startButton;
    public AudioSource backgroundMusic;

    // Update is called once per frame
    public void startlevel()
    {
        level2panel.SetActive(false);
        levelDescription.SetActive(false);
        startButton.SetActive(false);
        Time.timeScale = 1f;
        backgroundMusic.Play();
    }
}
