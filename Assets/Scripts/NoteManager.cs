using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NoteManager : MonoBehaviour
{
    public static NoteManager INSTANCE { get; private set; }

    public TextMeshProUGUI textArea;
    public Image imageArea;
    private Image panel;

    private bool reading;
    
    void Start()
    {
        INSTANCE = this;
        panel = GetComponent<Image>();
    }

    private void Update()
    {
        if ( (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Escape)) && reading)
        {
            LeaveNote();
        } 
    }

    public void ReadNote(Note note)
    {
        reading = true;
        AudioManager.instance.Play("Note");
        panel.enabled = true;
        Time.timeScale = 0.005f;
        textArea.enabled = true;
        textArea.text = note.message;
        if (note.image != null)
        {
            imageArea.enabled = true;
            imageArea.sprite = note.image;
        }else
        {
            imageArea.enabled = false;
        }
    }

    private void LeaveNote()
    {
        AudioManager.instance.Play("Note");
        reading = false;
        Time.timeScale = 1f;
        imageArea.enabled = false;
        textArea.enabled = false;
        panel.enabled = false;
    }
}
