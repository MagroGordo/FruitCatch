using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.Arm;

public class FruitManager : MonoBehaviour
{
    private Hernando hernando;

    private void Start()
    {
       hernando = FindObjectOfType<Hernando>();
    }
    private void Update()
    {
        PlayerPrefs.SetInt("LemonCollected", hernando.lemonCount);
        PlayerPrefs.SetInt("BananaCollected", hernando.bananaCount);
        PlayerPrefs.SetInt("OrangeCollected", hernando.orangeCount);
        PlayerPrefs.SetInt("StrawberryCollected", hernando.strawberryCount);
        PlayerPrefs.SetInt("WatermelonCollected", hernando.watermelonCount);
        PlayerPrefs.SetInt("MelonCollected", hernando.melonCount);
        PlayerPrefs.SetInt("KiwiCollected", hernando.kiwiCount);
        PlayerPrefs.SetInt("PineappleCollected", hernando.pineappleCount);
        PlayerPrefs.Save();
    }
}
