using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jordans : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private UpgradeManager upgrade_;

    private int upgradeIndex = 0;

    public void PurchaseUpgrade()
    {
        upgrade_.PurchaseUpgrade(upgradeIndex);
    }
}
