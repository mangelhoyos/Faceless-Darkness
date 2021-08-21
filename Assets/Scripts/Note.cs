using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class Note : ScriptableObject
{
    public string entry;
    
    [TextArea]
    public string message;
    public Sprite image;
}
