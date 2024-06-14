using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject jordans;
    [SerializeField] private TextMeshProUGUI talk;

    private string upgradePurchasedKey = "JordansPurchased";
    public bool upgradePurchased;

    void Start()
    {
        LoadUpgradeStatus();
        talk.text = "Hello buddy! What can I help you with today?";
    }

    public void PurchaseUpgrade(int requiredFruits, int upgradeIndex)
    {
        int strawberry = PlayerPrefs.GetInt("StrawberryCollected", 0);
        int orange = PlayerPrefs.GetInt("OrangeCollected", 0);
        int kiwi = PlayerPrefs.GetInt("KiwiCollected", 0);
        int lemon = PlayerPrefs.GetInt("LemonCollected", 0);

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

                // Update PlayerPrefs with new values
                PlayerPrefs.SetInt("OrangeCollected", orange);
                PlayerPrefs.SetInt("KiwiCollected", kiwi);
                PlayerPrefs.SetInt("StrawberryCollected", strawberry);
                PlayerPrefs.SetInt("LemonCollected", lemon);
                PlayerPrefs.Save();

                SaveUpgradeStatus(); // Call to save the upgrade status

                talk.text = "Thank you for purchasing and good luck on your adventures!";
            }
            else
            {
                talk.text = "Sorry buddy, looks like you don't have enough fruits. Be sure to bring me 100 oranges, 100 kiwis, 100 strawberries, and 100 lemons!";
            }
        }
    }

    private void SaveUpgradeStatus()
    {
        PlayerPrefs.SetInt(upgradePurchasedKey, upgradePurchased ? 1 : 0); // Use the variable, not the string
        PlayerPrefs.Save();
    }

    private void LoadUpgradeStatus()
    {
        upgradePurchased = PlayerPrefs.GetInt(upgradePurchasedKey, 0) == 1; // Set the class variable

        if (upgradePurchased)
        {
            jordans.SetActive(false);
        }
        else
        {
            jordans.SetActive(true);
        }
    }
}
