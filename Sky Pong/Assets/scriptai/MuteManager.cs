using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class MuteManager : MonoBehaviour
{
    // Start is called before the first frame update
    private bool IsMuted;
    public Toggle toggle;
    public Sprite on;
    public Sprite off;
    private int counter = 0;


    void Start()
    {
        toggle = GetComponent<Toggle>();
    }
    public void changelog()

    {
        counter++;
        if (counter % 2 == 0)
        {
            toggle.image.overrideSprite = on;
        }
        else
        {
            toggle.image.overrideSprite = off;
        }

    }




    public void Mute()
    {
        IsMuted = !IsMuted;
        AudioListener.pause = IsMuted;
    }



}
