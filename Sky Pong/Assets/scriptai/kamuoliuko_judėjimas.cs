using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamuoliuko_judėjimas : MonoBehaviour
{
    Vector3 padetis;
    public bool servas;
    public float eile;
    float servassum;
    void Start()
    {
        servassum = 1;
        eile = 1;
        padetis = transform.position;
        servas = GetComponent<Rigidbody>().isKinematic = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("siena"))
        {
            if (eile == 4)
                eile = 0;  
            eile++;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            if (eile <= 2)
            {
                transform.position = new Vector3(-3.77f, 2.2f, 0);
                servas = GetComponent<Rigidbody>().isKinematic = true;
            }
            if (eile > 2)
            {
                transform.position = new Vector3(3.77f, 2.2f, 0);
                servas = GetComponent<Rigidbody>().isKinematic = true;
            } 
        }
        if (collision.transform.CompareTag("stalas"))
        {
            servassum++;
            if(servassum == 2)
            {
                servas = false;
                servassum = 1;
            }
        }
    }
    




    ///sitas atsimusa priesinga kryptimi nei atskrido
    ///if (collision.gameObject.tag == "stalas")  
    //{

    ///Vector3 dir = collision.contacts[0].point - transform.position + new Vector3(0, 10, 0);
    ///dir = -dir.normalized;
    ///GetComponent<Rigidbody>().AddForce(dir * greitis);
    //}



}

