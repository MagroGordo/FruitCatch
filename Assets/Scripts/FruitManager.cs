using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitManager : MonoBehaviour
{
    private Hernando hernando;

    private void Start()
    {
       hernando = FindObjectOfType<Hernando>();
    }
    private void Update()
    {
        PlayerPrefs.SetInt("KiwiCollected", hernando.kiwiCount);
        PlayerPrefs.SetInt("PineappleCollected", hernando.pineappleCount);
        PlayerPrefs.SetInt("BananaCollected", hernando.bananaCount);
        PlayerPrefs.SetInt("LemonCollected", hernando.lemonCount);
        PlayerPrefs.SetInt("MelonCollected", hernando.melonCount);
        PlayerPrefs.SetInt("StrawberryCollected", hernando.strawberryCount);
        PlayerPrefs.Save();
    }
}
