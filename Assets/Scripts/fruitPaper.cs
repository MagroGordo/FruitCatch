using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System;

public class fruitPaper : MonoBehaviour
{
    [SerializeField] private GameObject paper;
    [SerializeField] private TextMeshProUGUI text;

    private int lemon;
    private int banana;
    private int orange;
    private int strawberry;
    private int watermelon;
    private int melon;
    private int kiwi;
    private int pineapple;

    private bool visible;

    private void Awake()
    {
        paper = GameObject.Find("Fruit Count");
    }

    private void Start()
    {
        lemon = PlayerPrefs.GetInt("LemonCollected");
        banana = PlayerPrefs.GetInt("BananaCollected");
        orange = PlayerPrefs.GetInt("OrangeCollected");
        strawberry = PlayerPrefs.GetInt("StrawberryCollected");
        watermelon = PlayerPrefs.GetInt("WatermelonCollected");
        melon = PlayerPrefs.GetInt("MelonCollected");
        kiwi = PlayerPrefs.GetInt("KiwiCollected");
        pineapple = PlayerPrefs.GetInt("PineappleCollected");

        visible = false;
        paper.SetActive(visible);
    }

    private void Update()
    {
        text.text = "lemon x" + lemon + 
            "\nbanana x" + banana +
            "\norange x" + orange +
            "\nstrawberry x" + strawberry +
            "\nwatermelon x" + watermelon +
            "\nmelon x" + melon +
            "\nkiwi x" + kiwi +
            "\npineapple x" + pineapple; 

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            visible = !visible;
            paper.SetActive(visible);
        }
    }
}
