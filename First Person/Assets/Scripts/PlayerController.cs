using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("stats")]
    public float moveSpeed;     // movement speed in units per second
    public float jumpForce;     // force applied to jump
    public int curHP;
    public int maxHP;
    [Header("Mouse Look")]
    public float lookSensetivity;       // Mouse sensitivity
    public float maxLookX;      // Maximum X position of the camera
    public float minLookX;      // Minimum X position of the camera
    private float rotX;     // Current x rotation of the camera
    [Header("Game Objects")]
    private Camera chamera;      // The camera used for the script
    private Rigidbody RB;       // The rigidbody of the current game object
    private Weapon blaster;
    void Awake()
    {
        // disable cursor
        Cursor.lockState = CursorLockMode.Locked;
        blaster = GetComponent<Weapon>();
    }
    // Start is called before the first frame update
    void Start()
    {
        // Get components
        chamera = Camera.main;
        RB = GetComponent<Rigidbody>();
        GameUI.instance.UpdateHealthBar(curHP, maxHP);
        GameUI.instance.UpdateScoreText(0);
        GameUI.instance.UpdateAmmoText(blaster.curAmmo, blaster.maxAmmo);
    }
    // Applies damage, and if their health goes to 0 or below, the KO function is called.
    public void TakeDamage(int damage)
    {
        curHP -= damage;
        if (curHP <= 0)
        {
            KO();
        }
        GameUI.instance.UpdateHealthBar(curHP, maxHP);
    }

    private void KO()
    {
        GameManager.instance.LoseGame();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;
        // RB.velocity = new Vector3(x, RB.velocity.y, z); - Old Code
        // Move direction relative to camera
        Vector3 dir = transform.right * x + transform.forward * z;
        RB.velocity = dir;
        dir.y = RB.velocity.y;
    }

    void camLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSensetivity;
        rotX += Input.GetAxis("Mouse Y") * lookSensetivity;

        rotX = Mathf.Clamp(rotX, minLookX, maxLookX);
        chamera.transform.localRotation = Quaternion.Euler(-rotX, 0, 0);
        transform.eulerAngles += Vector3.up * y;
    }

    void jumpUp()
    {
        Ray rayy = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(rayy, 1.1f))
        {
            RB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    public void GiveHealth(int ammountToGive)
    {
        curHP = Mathf.Clamp(curHP + ammountToGive, 0, maxHP);
        GameUI.instance.UpdateHealthBar(curHP, maxHP);
    }

    public void GiveAmmo(int ammountToGive)
    {
        blaster.curAmmo = Mathf.Clamp(blaster.curAmmo + ammountToGive, 0, blaster.maxAmmo);
        GameUI.instance.UpdateAmmoText(blaster.curAmmo, blaster.maxAmmo);
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        camLook();
        // Fire button
        if (Input.GetButton("Fire1"))
        {
            if (blaster.CanShoot())
            {
                blaster.Shoot();
            }
        }
        if (Input.GetButtonDown("Jump"))
        {
            jumpUp();
        }
        if(GameManager.instance.gamePaused == true)
        {
            return;
        }
    }
}
