using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;     // movement speed in units per second
    public float jumpForce;     // force applied to jump
    public float lookSensetivity;       // Mouse sensitivity
    public float maxLookX;      // Maximum X position of the camera
    public float minLookX;      // Minimum X position of the camera
    private float rotX;     // Current x rotation of the camera
    private Camera chamera;      // The camera used for the script
    private Rigidbody RB;       // The rigidbody of the current game object
    // Start is called before the first frame update
    void Start()
    {
        // Get components
        chamera = Camera.main;
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;
        RB.velocity = new Vector3(x, RB.velocity.y, z);
    }

    void camLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSensetivity;
        rotX += Input.GetAxis("Mouse Y") * lookSensetivity;
    }
}
