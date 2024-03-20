using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jordans : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private UpgradeManager upgrade_;
    [SerializeField] private Hernando hernando;
    [SerializeField] private GameObject jordans;

    private int updateIndex = 1;

    public void PurchaseUpgrade()
    {
        if (hernando.strawberryCount >= 25 &&
            hernando.lemonCount >= 10 &&
            hernando.bananaCount >= 10 &&
            hernando.watermelonCount >= 10 &&
            hernando.kiwiCount >= 10)
        {
            jordans.SetActive(false);
            upgrade_.PurchaseUpgrade(updateIndex);

            hernando.strawberryCount -= 25;
            hernando.lemonCount -= 10;
            hernando.bananaCount -= 10;
            hernando.watermelonCount -= 10;
            hernando.kiwiCount -= 10;
        }
        else
        {
            Debug.Log("Not enough fruits");
        }
    }
}
