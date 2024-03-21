using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject oinky;
    [SerializeField] private GameObject jordans;

    private string[] upgradePurchasedKeys = { "JordansPurchased", "OinkyPurchased"};
    public bool[] upgradePurchased = new bool[2];

    void Start()
    {
        LoadUpgradeStatus();
    }

    public void PurchaseUpgrade(int upgradeIndex, int requiredFruits)
    {
        int watermelon = PlayerPrefs.GetInt("WatermelonCollected", 0);
        int strawberry = PlayerPrefs.GetInt("StrawberryCollected", 0);
        int melon = PlayerPrefs.GetInt("MelonCollected", 0);
        int pineapple = PlayerPrefs.GetInt("PineappleCollected", 0);
        int orange = PlayerPrefs.GetInt("OrangeCollected", 0);
        int kiwi = PlayerPrefs.GetInt("KiwiCollected", 0);
        int banana = PlayerPrefs.GetInt("BananaCollected", 0);
        int lemon = PlayerPrefs.GetInt("LemonCollected", 0);

        if (upgradeIndex == 0)
        {
            if(kiwi >= requiredFruits &&
               strawberry >= requiredFruits &&
               orange >= requiredFruits &&
               lemon >= requiredFruits)
            {
                jordans.SetActive(false);
                upgradePurchased[upgradeIndex] = true;

                orange -= 150;
                kiwi -= 150;
                strawberry -= 150;
                lemon -= 150;

                PlayerPrefs.SetInt("OrangeCollected", orange);
                PlayerPrefs.SetInt("KiwiCollected", kiwi);
                PlayerPrefs.SetInt("StrawberryCollected", strawberry);
                PlayerPrefs.SetInt("LemonCollected", lemon);
                PlayerPrefs.Save();
            }
            else
            {
                Debug.Log("Not enough fruits");
            }
        }
        else if (upgradeIndex == 1)
        {
            if(watermelon >= requiredFruits &&
               banana >= requiredFruits &&
               pineapple >= requiredFruits &&
               melon >= requiredFruits)
            {
                oinky.SetActive(false);
                upgradePurchased[upgradeIndex] = true;

                watermelon -= 300;
                banana -= 300;
                pineapple -= 300;
                melon -= 300;

                PlayerPrefs.SetInt("WatermelonCollected", watermelon);
                PlayerPrefs.SetInt("BananaCollected", banana);
                PlayerPrefs.SetInt("PineappleCollected", pineapple);
                PlayerPrefs.SetInt("MelonCollected", melon);
                PlayerPrefs.Save();
            }
            else
            {
                Debug.Log("Not enough fruits");
            }
        }
    }

    void SaveUpgradeStatus(int upgradeIndex)
    {
        PlayerPrefs.SetInt(upgradePurchasedKeys[upgradeIndex], upgradePurchased[upgradeIndex] ? 1 : 0);
        PlayerPrefs.Save();
    }

    void LoadUpgradeStatus()
    {
        for (int i = 0; i < upgradePurchased.Length; i++)
        {
            if (PlayerPrefs.HasKey(upgradePurchasedKeys[i]))
            {
                upgradePurchased[i] = PlayerPrefs.GetInt(upgradePurchasedKeys[i]) == 1;
            }
        }
    }
}