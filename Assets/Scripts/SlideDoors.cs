using System;
using UnityEngine;

public class SlideDoors : MonoBehaviour
{
    public Transform doorUp;
    public Transform doorDown;

    private Vector2 vDoorUp;
    private Vector2 vDoorDown;

    public float slideSpeed;

    public float horizontalOffset;
    public float verticalOffset;

    private bool closing = false;
    
    void Start()
    {
        vDoorUp = doorUp.position;
        vDoorDown = doorDown.position;
    }

    private void Update()
    {
        if (closing)
        {
            CloseDoor();   
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.instance.Play("OpenDoor");
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            closing = false;
            OpenDoor();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            closing = true;
            AudioManager.instance.Play("OpenDoor");
        }
    }

    private void OpenDoor()
    {
        doorUp.position = Vector2.MoveTowards(doorUp.position, new Vector2(vDoorUp.x - horizontalOffset, vDoorUp.y + verticalOffset), slideSpeed * Time.deltaTime);
        doorDown.position = Vector2.MoveTowards(doorDown.position, new Vector2(vDoorDown.x + horizontalOffset, vDoorDown.y - verticalOffset), slideSpeed * Time.deltaTime);
    }

    private void CloseDoor()
    {
        doorUp.position = Vector2.MoveTowards(doorUp.position, vDoorUp, slideSpeed * Time.deltaTime);
        doorDown.position = Vector2.MoveTowards(doorDown.position, vDoorDown, slideSpeed * Time.deltaTime);
        if (Vector2.Distance(doorUp.position, vDoorUp) <= 0f &&
            Vector2.Distance(doorDown.position, vDoorDown) <= 0f)
        {
            closing = false;
        }
    }
}
