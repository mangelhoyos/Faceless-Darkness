using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BoxCollider2D initialDoor;
    public BoxCollider2D lastDoor;
    
    [HideInInspector]
    public bool buttonPressed;
    [HideInInspector]
    public byte amountOfPieces = 0;

    private bool initial, last;
    
    public static GameManager INSTANCE { get; private set; }

    private void Start()
    {
        INSTANCE = this;
    }

    public void AddSavagePiece()
    {
        amountOfPieces++;
        if (amountOfPieces >= 2 && buttonPressed && !initial)
        {
            initial = true;
            initialDoor.enabled = true;
            InspectorManager.INSTANCE.ChangeText("This opened a door somewhere");
        }

        if (amountOfPieces >= 4 && !last)
        {
            last = true;
            lastDoor.enabled = true;
            InspectorManager.INSTANCE.ChangeText("A door opened somewhere");
        }
    }

    public void ButtonPress()
    {
        if (amountOfPieces >= 2)
        {
            buttonPressed = true;
            initialDoor.enabled = true;
            InspectorManager.INSTANCE.ChangeText("This opened a door somewhere");
        }
        else
        {
            buttonPressed = true;
            InspectorManager.INSTANCE.ChangeText("It opened, but i have to find the other parts");
        }
    }
}
