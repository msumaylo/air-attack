using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityRemover : MonoBehaviour
{
    private float xRange = 16.5f;
    private float zRange = 11.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > xRange || transform.position.x < -xRange)
        {
            Destroy(gameObject);
        }

        if(transform.position.z > zRange || transform.position.z < -zRange)
        {
            Destroy(gameObject);
        }
    }
}
