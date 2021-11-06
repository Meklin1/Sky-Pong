using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bot_parent : MonoBehaviour
{
    Animator animacija1;
    public Transform Bot_Taikinys;
    public Transform kamuoliukas;
    public float jega = 8f;
    public float virsus = 1;
    Vector3 judejimopozicija;
    float rand1;
    bool servas;
    float eile;
    float greitis;
    void Start()
    {
        animacija1 = GetComponent<Animator>();
        judejimopozicija = transform.position;
        rand1 = GameObject.Find("rakete").GetComponent<Žaidėjo_raketės_judėjimas>().rand;
    }

    void FixedUpdate()
    {
        greitis = GameObject.Find("Bot_Rakete").GetComponent<Bot_raketės_judėjimas>().greitis;
        Debug.Log(greitis);
        servas = GameObject.Find("kamuoliukas").GetComponent<kamuoliuko_judėjimas>().servas;
        if (kamuoliukas.position.x >= 0 && !servas)
        {
            judejimopozicija.z = kamuoliukas.position.z;
            transform.position = Vector3.MoveTowards(transform.position, judejimopozicija, greitis * Time.deltaTime);
        }
        if (kamuoliukas.position.x < 0 || servas)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(4, 2.3f, 0), 5 * Time.deltaTime);
        }
    }



}