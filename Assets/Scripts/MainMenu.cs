using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void Start()
    {
        button.Select();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameIntro");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void OnMouseDown()
    {
        button.Select();
    }
}
