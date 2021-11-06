using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot_raketės_judėjimas : MonoBehaviour
{
    Animator animacija1;
    public Transform Bot_Taikinys;
    public Transform kamuoliukas;
    public Transform bot_parent;
    public float jega = 8f;
    public float virsus = 1f;
    public float servas_pirmyn = 8f;
    public float servas_virsus = 1f;
    Vector3 judejimopozicija;
    float rand1;
    bool servas;
    float eile;
    public bool smugis;
    float rand;
    public float greitis = 10f;
    public int range = 10;
    public float judgreitis = 3f;
    Quaternion pradinerot;
    public bool botservas;
    void Start()
    {
        pradinerot = transform.rotation;
        var targetRotation = Quaternion.LookRotation(transform.position);
        smugis = true;
        animacija1 = GetComponent<Animator>();
        judejimopozicija = transform.position;
    }

    void FixedUpdate()
    {
        if (servas && eile > 2 && smugis)
        {

            StartCoroutine(dvisek());
            smugis = false;
        }
        if (!servas)
            smugis = true;
        eile = GameObject.Find("kamuoliukas").GetComponent<kamuoliuko_judėjimas>().eile;
        servas = GameObject.Find("kamuoliukas").GetComponent<kamuoliuko_judėjimas>().servas;
        if (kamuoliukas.position.x < 0 || servas)
        {
            transform.rotation = pradinerot;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("kamuoliukas") && !servas)
        {
            rand = Random.Range(0, range);
            if (rand < range - 1)
                greitis = 10;
            if (rand == range - 1)
                greitis = judgreitis;
            GetComponent<AudioSource>().Play();
            Vector3 dir = Bot_Taikinys.position - transform.position;
            other.GetComponent<Rigidbody>().velocity = dir.normalized * jega + new Vector3(0, virsus, 0);
            animacija1.Play("boto raketes animacija", -1, 0f);
            

        }
    }
    private IEnumerator dvisek()
    {
        yield return new WaitForSeconds(2);        
        GetComponent<AudioSource>().Play();
        Vector3 dir = Bot_Taikinys.position - transform.position;
        kamuoliukas.GetComponent<Rigidbody>().isKinematic = false;
        kamuoliukas.GetComponent<Rigidbody>().velocity = dir.normalized * servas_pirmyn + new Vector3(0, servas_virsus, 0);       
    }
}