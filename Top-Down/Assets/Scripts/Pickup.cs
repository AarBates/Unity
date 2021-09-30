using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public string pickupName;
    public int amount;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.back * 100 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("you picked up a " + pickupName + "!");
        gameManager.hasKey = true;
        Destroy(gameObject);
    }
}
