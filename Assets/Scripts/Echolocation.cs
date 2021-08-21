using System;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class Echolocation : MonoBehaviour
{
    public TextMeshProUGUI batteryDisplay;
    
    public static Echolocation INSTANCE { get; private set; }

    [Header("Config")]
    public GameObject maskPrefab;
    public float rechargeSpeed;
    
    private float actualBattery;
    private const int MAXBATTERY = 100;
    
    //Delay
    public float echoDelay;
    private float actualDelay;

    private void Start()
    {
        INSTANCE = this;
        actualBattery = MAXBATTERY;
        actualDelay = echoDelay;
    }

    void Update()
    {
        actualDelay += Time.deltaTime;
        
        if (Input.GetKeyDown(KeyCode.V) && actualBattery >= 30 && actualDelay >= echoDelay)
        {
            actualDelay = 0;
            EchoTransmit();
        }

        if (Input.GetKey(KeyCode.R))
        {
            actualBattery += rechargeSpeed * Time.deltaTime;
            actualBattery = Mathf.Clamp(actualBattery, 0, MAXBATTERY);
            batteryDisplay.text = Convert.ToInt32(actualBattery).ToString();
        }
    }

    private void EchoTransmit()
    {
        AudioManager.instance.Play("Echo");
        actualBattery -= 30;
        GameObject echo = Instantiate(maskPrefab, transform.position, quaternion.identity);
        Destroy(echo,10f);
        batteryDisplay.text = Convert.ToInt32(actualBattery).ToString();
        if (actualBattery <= 30)
        {
            InspectorManager.INSTANCE.ChangeText("Hold R to reload your battery");
        }
    }

    public void CreateEcho(Vector2 position)
    {
        GameObject echo = Instantiate(maskPrefab, position, quaternion.identity);
        Destroy(echo,10f);
    }
}
