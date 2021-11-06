using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class pagrmenu : MonoBehaviour
{
    public Animator perej;
    // Start is called before the first frame update
    
    public void PlayGame ()
    {
        StartCoroutine(lvlis(1));
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void Play2()
    {
        StartCoroutine(lvlis(2));
    }
    public void Play3()
    {
        StartCoroutine(lvlis(3));
    }
    IEnumerator lvlis(int levelindex)
    {
        perej.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelindex);
    }

    public void Play4()
    {
        StartCoroutine(lvlis(4));
    }
    public void Play5()
    {
        StartCoroutine(lvlis(5));
    }
    public void Play6()
    {
        StartCoroutine(lvlis(6));
    }

}
