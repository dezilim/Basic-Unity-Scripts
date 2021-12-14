using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextManager : MonoBehaviour
{
    public float timeStart;
    public static int kittiesAwakeNb;
    public static int newsPaperNb;
    public static int sceneNb;

    Scene scene;
    public GameObject FinishedLevelUI, gameCanvasUI;
    public Text timeLeft, productionCount, scoreCount, levelscore;
    public AudioSource backgroundMusic;


    // Start is called before the first frame update
    void Start()
    {
        // get scene index
        scene = SceneManager.GetActiveScene();
        sceneNb = scene.buildIndex;
        Debug.Log("Scene no: " + sceneNb);

        timeStart = 120;
        timeLeft.text = timeStart.ToString();
        newsPaperNb = 0;

        kittiesAwakeNb = sceneNb + 1;

    }

    // Update is called once per frame
    void Update()
    {
        
        timeLeft.text = Mathf.Round(timeStart).ToString();
        productionCount.text = kittiesAwakeNb.ToString();
        scoreCount.text = newsPaperNb.ToString();

        if (Mathf.Round(timeStart) != 0f)
        {
            timeStart -= Time.deltaTime;
        } // load scene2 menu
        else if (sceneNb == 0)
        {
            timeStart = 0;
            timeLeft.text = timeStart.ToString();
            Time.timeScale = 0f;
            gameCanvasUI.SetActive(false);
            FinishedLevelUI.SetActive(true);
            levelscore.text = newsPaperNb.ToString();
            backgroundMusic.Stop();
        }
        else if (sceneNb == 1)
        {
            timeStart = 0;
            timeLeft.text = timeStart.ToString();
            Time.timeScale = 0f;
            gameCanvasUI.SetActive(false);
            FinishedLevelUI.SetActive(true);
            levelscore.text = newsPaperNb.ToString();
            backgroundMusic.Stop();
        }

        else if (sceneNb == 2)
        {
            timeStart = 0;
            timeLeft.text = timeStart.ToString();
            Time.timeScale = 0f;
            gameCanvasUI.SetActive(false);
            FinishedLevelUI.SetActive(true);
            levelscore.text = newsPaperNb.ToString();
            backgroundMusic.Stop();
        }

    }
}
