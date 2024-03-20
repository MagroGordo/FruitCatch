using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    private string[] upgradePurchasedKeys = { "JordansPurchased", "OinkyPurchased"};
    public bool[] upgradePurchased = new bool[2];


    void Start()
    {
        LoadUpgradeStatus();
    }

    public void PurchaseUpgrade(int upgradeIndex)
    {
        upgradePurchased[upgradeIndex] = true;
        SaveUpgradeStatus(upgradeIndex);
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