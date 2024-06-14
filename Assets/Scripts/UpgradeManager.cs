using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject jordans;
    [SerializeField] private TextMeshProUGUI talk;

    private string upgradePurchasedKey = "JordansPurchased";
    private int requiredFruits = 50; // Adjust as per your game design

    void Start()
    {
        LoadUpgradeStatus();
        talk.text = "Ciao Hernandito! What can I help you with today?";
    }

    public void PurchaseUpgrade()
    {
        int strawberry = PlayerPrefs.GetInt("StrawberryCollected", 0);
        int orange = PlayerPrefs.GetInt("OrangeCollected", 0);
        int kiwi = PlayerPrefs.GetInt("KiwiCollected", 0);
        int lemon = PlayerPrefs.GetInt("LemonCollected", 0);

        // Check if player has enough fruits to purchase upgrade
        if (kiwi >= requiredFruits &&
            strawberry >= requiredFruits &&
            orange >= requiredFruits &&
            lemon >= requiredFruits)
        {
            // Subtract fruits from player's PlayerPrefs values
            kiwi -= requiredFruits;
            strawberry -= requiredFruits;
            orange -= requiredFruits;
            lemon -= requiredFruits;

            PlayerPrefs.SetInt("KiwiCollected", kiwi);
            PlayerPrefs.SetInt("StrawberryCollected", strawberry);
            PlayerPrefs.SetInt("OrangeCollected", orange);
            PlayerPrefs.SetInt("LemonCollected", lemon);
            PlayerPrefs.Save();

            // Set upgrade as purchased
            SaveUpgradeStatus();

            // Hide the upgrade object
            jordans.SetActive(false);

            // Update UI or feedback to player
            talk.text = "Grazzie mille Hernandito! Come again!";
        }
        else
        {
            // Inform player they don't have enough fruits
            talk.text = "Qué cosa Hernandito! Looks like you don't have enough fruits. Be sure to bring me 50 oranges, 50 kiwis, 50 strawberries and 50 lemons for that pair of jordans";
        }
    }

    private void SaveUpgradeStatus()
    {
        // Save upgrade purchased status
        PlayerPrefs.SetInt(upgradePurchasedKey, 1);
        PlayerPrefs.Save();

        // Optionally, you can set an internal boolean to track this
        // This is useful if you need to query the status elsewhere in the code
        // upgradePurchased = true;
    }

    private void LoadUpgradeStatus()
    {
        // Load upgrade purchased status
        int upgradePurchasedValue = PlayerPrefs.GetInt(upgradePurchasedKey, 0);
        if (upgradePurchasedValue == 1)
        {
            jordans.SetActive(false); // Hide the upgrade object
        }
        else
        {
            jordans.SetActive(true); // Show the upgrade object
        }
    }
}