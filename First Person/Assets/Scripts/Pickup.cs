using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public PickupType type;
    public int value;
    private Vector3 startPos;
    [Header("Bobbing Motion")]
    public float rotationSpeed;
    public float bobSpeed;
    public float bobHeight;
    private bool isBobbing;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    public enum PickupType
    {
        Health,
        Ammo
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            switch(type)
            {
                case PickupType.Health:
                    player.GiveHealth(value);
                    break;
                case PickupType.Ammo:
                    player.GiveAmmo(value);
                    break;
                default:
                    print("Type not accepted");
                    break;
            }
            // Call the game manager to play pick up sound effect
            GameManager.sfxInstance.source.PlayOneShot(GameManager.sfxInstance.pickUp);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        Vector3 offset = (isBobbing == true ? new Vector3(0, bobHeight / 2, 0) : new Vector3(0, -bobHeight, 0));
        transform.position = Vector3.MoveTowards(transform.position, startPos + offset, bobSpeed * Time.deltaTime);
        if(transform.position == startPos + offset)
        {
            isBobbing = !isBobbing;
        }
    }
}
