using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smugis_virsun : MonoBehaviour
{
    public float jega = 10f;
    bool servas;
    void Update()
    {
        servas = GameObject.Find("kamuoliukas").GetComponent<kamuoliuko_judėjimas>().servas;
    }
    private void OnCollisionEnter(Collision collision)
    {     
        if (collision.gameObject.tag == "kamuoliukas")
        {
            GetComponent<AudioSource>().Play();
            if (servas)             
               collision.gameObject.GetComponent<Rigidbody>().AddForce(0, 0, 0);
            if(!servas)
                collision.gameObject.GetComponent<Rigidbody>().AddForce(0, jega, 0);
        }

    }
}
