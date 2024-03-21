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
        watermelonCount = PlayerPrefs.GetInt("WatermelonCollected", 0);
        strawberryCount = PlayerPrefs.GetInt("StrawberryCollected", 0);
        melonCount = PlayerPrefs.GetInt("MelonCollected", 0);
        pineappleCount = PlayerPrefs.GetInt("PineappleCollected", 0);
        orangeCount = PlayerPrefs.GetInt("OrangeCollected", 0);
        kiwiCount = PlayerPrefs.GetInt("KiwiCollected", 0);
        bananaCount = PlayerPrefs.GetInt("BananaCollected", 0);
        lemonCount = PlayerPrefs.GetInt("LemonCollected", 0);
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

        watermelonCount = PlayerPrefs.GetInt("WatermelonCollected", 0);
        strawberryCount = PlayerPrefs.GetInt("StrawberryCollected", 0);
        melonCount = PlayerPrefs.GetInt("MelonCollected", 0);
        pineappleCount = PlayerPrefs.GetInt("PineappleCollected", 0);
        orangeCount = PlayerPrefs.GetInt("OrangeCollected", 0);
        kiwiCount = PlayerPrefs.GetInt("KiwiCollected", 0);
        bananaCount = PlayerPrefs.GetInt("BananaCollected", 0);
        lemonCount = PlayerPrefs.GetInt("LemonCollected", 0);
    }
}   
