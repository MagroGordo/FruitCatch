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
    private int requiredFruits = 300;

    public void PurchaseUpgrade()
    {
        upgrade_.PurchaseUpgrade(updateIndex, requiredFruits);
    }
}
