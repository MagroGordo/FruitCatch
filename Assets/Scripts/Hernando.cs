using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hernando : MonoBehaviour
{
    public int lemonCount;
    public int bananaCount;
    public int orangeCount;
    public int strawberryCount;
    public int watermelonCount;
    public int melonCount;
    public int kiwiCount;
    public int pineappleCount;

    private void Start()
    {
        watermelonCount = PlayerPrefs.GetInt("WatermelonCollected", watermelonCount);
        strawberryCount = PlayerPrefs.GetInt("StrawberryCollected", strawberryCount);
        melonCount = PlayerPrefs.GetInt("MelonCollected", melonCount);
        pineappleCount = PlayerPrefs.GetInt("PineappleCollected", pineappleCount);
        orangeCount = PlayerPrefs.GetInt("OrangeCollected", orangeCount);
        kiwiCount = PlayerPrefs.GetInt("KiwiCollected", kiwiCount);
        bananaCount = PlayerPrefs.GetInt("BananaCollected", bananaCount);
        lemonCount = PlayerPrefs.GetInt("LemonCollected", lemonCount);
    }

    private void Update()
    {
        PlayerPrefs.SetInt("WatermelonCollected", watermelonCount);
        PlayerPrefs.SetInt("StrawberryCollected", strawberryCount);
        PlayerPrefs.SetInt("MelonCollected", melonCount);
        PlayerPrefs.SetInt("PineappleCollected", pineappleCount);
        PlayerPrefs.SetInt("OrangeCollected", orangeCount);
        PlayerPrefs.SetInt("KiwiCollected", kiwiCount);
        PlayerPrefs.SetInt("BananaCollected", bananaCount);
        PlayerPrefs.SetInt("LemonCollected", lemonCount);
    }
}   
