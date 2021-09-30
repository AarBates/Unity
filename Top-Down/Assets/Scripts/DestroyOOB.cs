using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOOB : MonoBehaviour
{
    public float xRange = 12.4f;
    public float yRange = 3.67f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > yRange)
        {
            Destroy(gameObject);
        }
        if(transform.position.x > xRange)
        {
            Destroy(gameObject);
        }
        if (transform.position.y < -yRange)
        {
            Destroy(gameObject);
        }
        if (transform.position.x < -xRange)
        {
            Destroy(gameObject);
        }
    }
}
