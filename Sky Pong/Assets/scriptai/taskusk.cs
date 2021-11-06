using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class taskusk : MonoBehaviour
{
    public Animator perej;
    public static int Score = 0;
    public static int Scorem = 0;
    public float restartDelay = 5000f;
    public Text scoreText;
    public Text scoreTextmano;
    public static bool Gamepaused = false;
    public bool scena = false;

    public GameObject pauseMenuUI;
    IEnumerator lvlis(int levelindex)
    {
        perej.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelindex);
    }

    // Update is called once per frame
    public GameObject lostLevelUI;
    public GameObject wonLevelUI;

    public void LostLevel()
    {
        //Invoke("unpauze", 0f);
        //Gamepaused = true;

        lostLevelUI.SetActive(true);
        scena = true;

    }
    public void WonLevel()
    {
        //Invoke("unpauze", 0f);
        //Gamepaused = true;

        wonLevelUI.SetActive(true);
        scena = true;
    }
    public void isj()
    {
        lostLevelUI.SetActive(false);
        wonLevelUI.SetActive(false);
    }


    public void LoadMenu()
    {
        scena = false;
        //CancelInvoke("pauze");
        Scorem = 0;
        Score = 0;


        StartCoroutine(lvlis(0));
    }

    public void Restart()
    {
        scena = false;
        //CancelInvoke("pauze");
        Scorem = 0;
        Score = 0;

        StartCoroutine(lvlis(SceneManager.GetActiveScene().buildIndex));

    }
    public void NextLevel()
    {
        scena = false;
        //CancelInvoke("pauze");
        Scorem = 0;
        Score = 0;
        StartCoroutine(lvlis(SceneManager.GetActiveScene().buildIndex + 1));


    }
    public void pauze()
    {
        Time.timeScale = 0f;
    }

    public void unpauze()
    {
        Time.timeScale = 1f;
        //Score = 0;
        //Scorem = 0;
    }
    public void Resume()
    {
        scena = false;
        pauseMenuUI.SetActive(false);

        Time.timeScale = 1f;
        Gamepaused = false;
    }
    void Pause()
    {
        scena = true;
        pauseMenuUI.SetActive(true);

        Time.timeScale = 0f;
        Gamepaused = true;
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    void Update()
    {
        Score.ToString();
        Scorem.ToString();
        scoreText.text = Score.ToString();
        scoreTextmano.text = Scorem.ToString();
        if (Scorem >= 11)
        {
            Invoke("WonLevel", 0f);
            //Invoke("pauze", 1f);


        }
        if (scena == false)
        {
            Invoke("unpauze", 0f);
            Time.timeScale = 1f;
            CancelInvoke("pauze");
        }
        if (scena == true)
        {
            Invoke("pauze", 0.15f);
        }
        //if (Gamepaused == true)
        //{
        // Time.timeScale = 0f;
        //}
        //if (Gamepaused == false)
        //{
        // Time.timeScale = 1f;
        //}


        if (Score >= 11)
        {
            Invoke("LostLevel", 0f);
            //Invoke("pauze", 1f);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Gamepaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }

}