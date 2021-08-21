using System;
using UnityEngine;

public class TakeSavagePart : MonoBehaviour
{
    private bool used;

    private SpriteRenderer sprenderer;

    private void Awake()
    {
        sprenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (other.CompareTag("Player") && !used)
            {
                AudioManager.instance.Play("Salvage");
                used = true;
                GameManager.INSTANCE.AddSavagePiece();
                InspectorManager.INSTANCE.ChangeText("One more savaged piece");
                sprenderer.color = Color.white;
            }
        }
    }
}
