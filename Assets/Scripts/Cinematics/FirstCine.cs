using UnityEngine;
using UnityEngine.Playables;

public class FirstCine : MonoBehaviour
{
    private PlayableDirector director;

    private bool used;

    private void Awake()
    {
        director = GetComponent<PlayableDirector>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && GameManager.INSTANCE.buttonPressed && !used)
        {
            director.Play();
            used = true;
        }
    }
}
