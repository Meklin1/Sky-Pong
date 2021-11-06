using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour
{
    public static int Score = 0;
    public static int Scorem = 0;
    public static bool Gamepaused = false;
    public GameObject pauseMenuUI;
    
    // Update is called once per frame

    
    void Update()
    {
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

    public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        
        Time.timeScale = 1f;
        Gamepaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        
        Time.timeScale = 0f;
        Gamepaused = true;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        
        SceneManager.LoadScene("menu");
        
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
