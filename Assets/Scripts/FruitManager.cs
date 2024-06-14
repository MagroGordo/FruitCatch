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
        PlayerPrefs.SetInt("LemonCollected", 0);
        PlayerPrefs.SetInt("BananaCollected", 0);
        PlayerPrefs.SetInt("OrangeCollected", 0);
        PlayerPrefs.SetInt("StrawberryCollected", 0);
        PlayerPrefs.SetInt("WatermelonCollected", 0);
        PlayerPrefs.SetInt("MelonCollected", 0);
        PlayerPrefs.SetInt("KiwiCollected", 0);
        PlayerPrefs.SetInt("PineappleCollected", 0);
        PlayerPrefs.Save();
    }
}
