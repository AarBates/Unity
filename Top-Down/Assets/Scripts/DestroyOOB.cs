using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOOB : MonoBehaviour
{
    public float topBound = 3.67f;
    public float sideBound = 12.4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > topBound)
        {
            Destroy(gameObject);
        }
        if(transform.position.x > sideBound)
        {
            Destroy(gameObject);
        }
        if (transform.position.y < -topBound)
        {
            Destroy(gameObject);
        }
        if (transform.position.x < -sideBound)
        {
            Destroy(gameObject);
        }
    }
}
