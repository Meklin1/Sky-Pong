using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class taskaib : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "botot")
        {
            taskusk.Score += 1;
        }
        if (collision.transform.name == "manot")
        {
            taskusk.Scorem += 1;
        }
    }
    
}
