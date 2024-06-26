using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static Unity.Burst.Intrinsics.Arm;

public class UpgradeManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject jordans;
    [SerializeField] private TextMeshProUGUI talk;

    private string upgradePurchasedKey = "JordansPurchased";
    private int requiredFruits = 10;

    public bool upgradePurchased;

    public Image image;
    public float displayTime = 2.0f;

    void Start()
    {
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

        Debug.Log("Current resources - Strawberry: " + strawberry + ", Orange: " + orange + ", Kiwi: " + kiwi + ", Lemon: " + lemon);

        if (upgradeIndex == 0)
        {
            if (kiwi >= requiredFruits &&
               strawberry >= requiredFruits &&
               orange >= requiredFruits &&
               lemon >= requiredFruits)
            {
                jordans.SetActive(false);
                upgradePurchased = true;

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
    }

    private void SaveUpgradeStatus()
    {
        PlayerPrefs.SetInt(upgradePurchasedKey, upgradePurchased ? 1 : 0);
        PlayerPrefs.Save();
    }

    private void LoadUpgradeStatus()
    {
        upgradePurchased = PlayerPrefs.GetInt(upgradePurchasedKey, 0) == 1;

        if (upgradePurchased)
        {
            jordans.SetActive(false);
        }
        else
        {
            jordans.SetActive(true);
        }
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
