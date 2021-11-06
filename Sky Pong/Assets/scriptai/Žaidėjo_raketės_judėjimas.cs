using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Žaidėjo_raketės_judėjimas : MonoBehaviour
{
    Animator animacija;
    public Transform kamuoliukas;
    public Transform Taikinys;
    public Transform Taikinys_1;
    public Transform Taikinys_2;
    public float jega_pirmyn = 8f;
    public float jega_virsun = 1;
    public float servo_jega_pirmyn = 8f;
    public float servo_jega_virsun = 1;
    public float rand;
    bool servas;
    float eile;

    void Start()
    {
        animacija = GetComponent<Animator>();
    }
    void Update()
    {
        eile = GameObject.Find("kamuoliukas").GetComponent<kamuoliuko_judėjimas>().eile;
        servas = GameObject.Find("kamuoliukas").GetComponent<kamuoliuko_judėjimas>().servas;
        rand = Random.Range(0, 3);
        if (Input.GetKeyDown("s"))
        {
            if (servas && eile <= 2)
            {
                animacija.Play("servas", -1, 0f);
                kamuoliukas.GetComponent<Rigidbody>().isKinematic = false;
            }
            else
                animacija.Play("raketes animacija", -1, 0f);

        }
        if (Input.GetKeyDown("a"))
        {
            animacija.Play("raketes animacija is kaires", -1, 0f);
        }
        if (Input.GetKeyDown("d"))
        {
            animacija.Play("raketes animacija is desines", -1, 0f);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("kamuoliukas") && servas && eile <= 2)
        {
            GetComponent<AudioSource>().Play();
            Vector3 dir = Taikinys.position - transform.position;
            other.GetComponent<Rigidbody>().velocity = dir.normalized * servo_jega_pirmyn + new Vector3(0, servo_jega_virsun, 0);
        }
        if (other.CompareTag("kamuoliukas") && !servas)
        {
            GetComponent<AudioSource>().Play();
            if (rand == 0)
            {
                Vector3 dir = Taikinys.position - transform.position;
                other.GetComponent<Rigidbody>().velocity = dir.normalized * jega_pirmyn + new Vector3(0, jega_virsun, 0);
            }
            if (rand == 1)
            {
                Vector3 dir = Taikinys_1.position - transform.position;
                other.GetComponent<Rigidbody>().velocity = dir.normalized * jega_pirmyn + new Vector3(0, jega_virsun, 0);
            }
            if (rand == 2)
            {
                Vector3 dir = Taikinys_2.position - transform.position;
                other.GetComponent<Rigidbody>().velocity = dir.normalized * jega_pirmyn + new Vector3(0, jega_virsun, 0);
            }
        }
    }
}