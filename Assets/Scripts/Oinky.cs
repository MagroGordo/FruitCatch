using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oinky : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private UpgradeManager upgrade_;
    [SerializeField] private Hernando hernando;
    [SerializeField] private GameObject oinky;

    private int updateIndex = 1;

    public void PurchaseUpgrade()
    {
        if (hernando.orangeCount >= 50 &&
            hernando.bananaCount >= 50 &&
            hernando.watermelonCount >= 50)
        {
            oinky.SetActive(false);
            upgrade_.PurchaseUpgrade(updateIndex);
        }
        else
        {
            Debug.Log("Not enough fruits");
        }
    }
}
