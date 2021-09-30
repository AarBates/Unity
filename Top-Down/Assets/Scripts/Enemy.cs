using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform nemesis;
    public float moveSpeed;
    public Rigidbody2D RB;
    private Vector2 movement;


    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = nemesis.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        RB.rotation = angle;
        dir.Normalize();
        movement = dir;
    }
    private void FixedUpdate()
    {
        MoveEnemy(movement);
    }
    void MoveEnemy(Vector2 angler)
    {
        RB.MovePosition((Vector2)transform.position + (angler * moveSpeed * Time.deltaTime));
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Projectile"))
        {
            print("Projectile hit enemy");
            Destroy(gameObject, 0.5f);
        }
    }
}
