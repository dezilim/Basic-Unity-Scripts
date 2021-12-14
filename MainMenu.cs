using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject player, startButton, mainMenuUI, gameCanvasUI;
    public GameObject story1, story2, story3, story4;
    public AudioSource backgroundMusic, menuMusic, flipSound;

    void Start()
    {
        Time.timeScale = 0f;
        player = GameObject.FindWithTag("Player1");
        player.GetComponent<PlayerMovement>().enabled = false;
        gameCanvasUI.SetActive(false);
    }

    // Update is called once per frame
    public void startGame()
    {
        Time.timeScale = 1f;
        mainMenuUI.SetActive(false);
        startButton.SetActive(false);
        player.GetComponent<PlayerMovement>().enabled = true;
        gameCanvasUI.SetActive(true);

        backgroundMusic.Play();
        menuMusic.Stop();
    }

    public void Next()
    {
        flipSound.Play();
        if (story1.activeSelf)
        {
            story1.SetActive(false);
            story2.SetActive(true);
        }
        else if (story2.activeSelf)
        {
            story2.SetActive(false);
            story3.SetActive(true);
        }
        else if (story3.activeSelf)
        {
            story3.SetActive(false);
            story4.SetActive(true);
        }
    }

    public void Back()
    {
        flipSound.Play();
        if (story2.activeSelf)
        {
            story2.SetActive(false);
            story1.SetActive(true);
        }

        if (story3.activeSelf)
        {
            story3.SetActive(false);
            story2.SetActive(true);
        }

        if (story4.activeSelf)
        {
            story4.SetActive(false);
            story3.SetActive(true);
        }
    }
}
