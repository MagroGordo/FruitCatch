using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oinky : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private UpgradeManager upgrade_;

    private int upgradeIndex = 1;

    public void PurchaseUpgrade()
    {
        upgrade_.PurchaseUpgrade(upgradeIndex);
    }
}
