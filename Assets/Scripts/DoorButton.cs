using System;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (other.CompareTag("Player"))
            {
                AudioManager.instance.Play("Unlock");
                GameManager.INSTANCE.ButtonPress();
            }
        }
    }
}
