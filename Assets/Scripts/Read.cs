using UnityEngine;

public class Read : MonoBehaviour
{
    public Note textSample;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (other.CompareTag("Player"))
            {
                NoteManager.INSTANCE.gameObject.SetActive(true);
                NoteManager.INSTANCE.ReadNote(textSample);
            }
        }
    }
}
