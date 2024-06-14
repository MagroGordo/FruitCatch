using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jordans : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private UpgradeManager upgrade_;

    public void PurchaseUpgrade()
    {
        upgrade_.PurchaseUpgrade();
    }
}
