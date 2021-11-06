using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posukiai : MonoBehaviour
{
    public Transform kamuoliukas;
    Animator animacija;
    bool servas;
    public Transform bot_parent;
    bool botservas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        botservas = GameObject.Find("Bot_Rakete").GetComponent<Bot_raketės_judėjimas>().botservas;
        servas = GameObject.Find("kamuoliukas").GetComponent<kamuoliuko_judėjimas>().servas;
        if (kamuoliukas.position.x >= 0 && !servas)
        {
            transform.eulerAngles = new Vector3(bot_parent.transform.position.z * 10, transform.eulerAngles.y, transform.eulerAngles.z);

        }
    }
}
