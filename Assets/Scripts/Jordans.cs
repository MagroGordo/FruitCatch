using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jordans : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private UpgradeManager upgrade_;

    private int updateIndex = 1;
    private int requiredFruits = 150;

    public void PurchaseUpgrade()
    {
        upgrade_.PurchaseUpgrade(updateIndex, requiredFruits);
    }
}
