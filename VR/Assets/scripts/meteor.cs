using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteor : MonoBehaviour
{



    void Start()
    {
        Vector3 offset;
        offset = new Vector3 (0.0f, 1.0f, 0.0f);

        gameObject.transform.position += offset;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y >= 1) 
        {
            transform.Translate(0f, -0.01f, 0);
        }
        else 
        {
            Destroy(gameObject);  
        }
    }
}
