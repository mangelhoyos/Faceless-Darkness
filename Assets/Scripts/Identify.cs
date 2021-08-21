using UnityEngine;

public class Identify : MonoBehaviour
{
    public Note textSample;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (other.CompareTag("Player"))
            {
                AudioManager.instance.Play("Think");
                InspectorManager.INSTANCE.ChangeText(textSample.message);
            }
        }
    }
}
