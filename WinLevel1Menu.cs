using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLevel1Menu : MonoBehaviour
{
    public AudioSource backgroundMusic;

    public GameObject FinishedLevel1UI;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void NextLevel()
    {
        if ((TextManager.sceneNb == 0 && TextManager.newsPaperNb >= 10) || (TextManager.sceneNb == 1 && TextManager.newsPaperNb >= 20))
        {
            Debug.Log("nextLevel");
            FinishedLevel1UI.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            backgroundMusic.Play();
        }
        
    }
    // Update is called once per frame
    public void Restart()
    {
        Debug.Log("restart");
        
        SceneManager.LoadScene(0, LoadSceneMode.Single);
        //Time.timeScale = 1f;
        //backgroundMusic.Play();
    }

    public void Quit()
    {
        Application.Quit();
        //FinishedLevel1UI.SetActive(false);
    }
}
