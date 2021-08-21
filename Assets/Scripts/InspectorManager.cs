using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class InspectorManager : MonoBehaviour
{
    private TextMeshProUGUI textContainer;

    private bool playing = false;

    public static InspectorManager INSTANCE{ get; private set; }

    private void Awake()
    {
        textContainer = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        INSTANCE = this;
    }

    public void ChangeText(string text)
    {
        if (!playing)
        {
            textContainer.text = text;
            StartCoroutine(WaitForClean());
        }
    }

    private IEnumerator WaitForClean()
    {
        playing = true;
        yield return new WaitForSeconds(4f);
        textContainer.text = " ";
        playing = false;
    }
}
