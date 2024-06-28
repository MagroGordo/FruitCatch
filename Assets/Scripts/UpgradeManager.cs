using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject jordans;
    [SerializeField] private GameObject oinky;
    [SerializeField] private TextMeshProUGUI talk;

    private string jordansPurchasedKey = "JordansPurchased";
    private string oinkyPurchasedKey = "OinkyPurchased";
    private int requiredFruits;

    public bool jordansPurchased;
    public bool oinkyPurchased;

    public Image image;
    public float displayTime = 2.0f;

    private AudioSource sound;

    void Start()
    {
        sound = GetComponent<AudioSource>();

        LoadUpgradeStatus();

        talk.text = "Ciao Hernandito! What can I help you with today?";
        ShowImage();
    }

    public void PurchaseUpgrade(int upgradeIndex)
    {
        int lemon = PlayerPrefs.GetInt("LemonCollected");
        int orange = PlayerPrefs.GetInt("OrangeCollected");
        int strawberry = PlayerPrefs.GetInt("StrawberryCollected");
        int kiwi = PlayerPrefs.GetInt("KiwiCollected");

        int banana = PlayerPrefs.GetInt("BananaCollected");
        int watermelon = PlayerPrefs.GetInt("WatermelonCollected");
        int melon = PlayerPrefs.GetInt("MelonCollected");
        int pineapple = PlayerPrefs.GetInt("PineappleCollected");

        if (upgradeIndex == 0)
        {
            requiredFruits = 10;

            if (kiwi >= requiredFruits &&
                strawberry >= requiredFruits &&
                orange >= requiredFruits &&
                lemon >= requiredFruits)
            {
                sound.Play();
                jordans.SetActive(false);
                jordansPurchased = true;

                orange -= requiredFruits;
                kiwi -= requiredFruits;
                strawberry -= requiredFruits;
                lemon -= requiredFruits;

                PlayerPrefs.SetInt("LemonCollected", lemon);
                PlayerPrefs.SetInt("OrangeCollected", orange);
                PlayerPrefs.SetInt("StrawberryCollected", strawberry);
                PlayerPrefs.SetInt("KiwiCollected", kiwi);

                PlayerPrefs.Save();

                SaveUpgradeStatus();

                talk.text = "Grazie mille Hernandito! Come again!";
                ShowImage();
            }
            else
            {
                talk.text = "Qué cosa Hernandito! Looks like you don't have enough fruits. Be sure to bring me " + requiredFruits + " oranges, " + requiredFruits + " kiwis, " + requiredFruits + " strawberries, and " + requiredFruits + " lemons for that pair of jordans";
                ShowImage();
            }
        }
        else if (upgradeIndex == 1)
        {
            requiredFruits = 20;

            if (banana >= requiredFruits &&
                watermelon >= requiredFruits &&
                melon >= requiredFruits &&
                pineapple >= requiredFruits)
            {
                sound.Play();
                oinky.SetActive(false);
                oinkyPurchased = true;

                banana -= requiredFruits;
                watermelon -= requiredFruits;
                melon -= requiredFruits;
                pineapple -= requiredFruits;

                PlayerPrefs.SetInt("BananaCollected", banana);
                PlayerPrefs.SetInt("WatermelonCollected", watermelon);
                PlayerPrefs.SetInt("MelonCollected", melon);
                PlayerPrefs.SetInt("PineappleCollected", pineapple);

                PlayerPrefs.Save();

                SaveUpgradeStatus();

                talk.text = "Grazie mille Hernandito! Come again!";
                ShowImage();
            }
            else
            {
                talk.text = "Qué cosa Hernandito! Looks like you don't have enough fruits. Be sure to bring me " + requiredFruits + " bananas, " + requiredFruits + " watermelons, " + requiredFruits + " melons, and " + requiredFruits + " pineapples for that oinky upgrade";
                ShowImage();
            }
        }
    }

    private void SaveUpgradeStatus()
    {
        PlayerPrefs.SetInt(jordansPurchasedKey, jordansPurchased ? 1 : 0);
        PlayerPrefs.SetInt(oinkyPurchasedKey, oinkyPurchased ? 1 : 0);
        PlayerPrefs.Save();
    }

    private void LoadUpgradeStatus()
    {
        jordansPurchased = PlayerPrefs.GetInt(jordansPurchasedKey, 0) == 1;
        oinkyPurchased = PlayerPrefs.GetInt(oinkyPurchasedKey, 0) == 1;

        jordans.SetActive(!jordansPurchased);
        oinky.SetActive(!oinkyPurchased);
    }

    public void ShowImage()
    {
        image.gameObject.SetActive(true);
        Invoke("HideImage", displayTime);
    }

    void HideImage()
    {
        image.gameObject.SetActive(false);
    }
}
