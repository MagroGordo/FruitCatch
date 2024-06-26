using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIRectTransformSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn;      // The prefab to spawn
    public RectTransform spawnArea;       // The RectTransform defining the spawn area
    public Button spawnButton;            // The UI button to trigger the spawn
    public Canvas canvas;                 // The Canvas the prefab will be parented to
    public TextMeshProUGUI costText;      // TextMeshProUGUI to display the cost
    public TextMeshProUGUI message;

    private int prefabsSpawned = 0;       // Number of prefabs spawned
    private int spawnCost = 1;            // Initial cost to spawn a prefab

    private const string SpawnedCountKey = "PrefabsSpawned";
    private const string PrefabPositionXKey = "PrefabPosX_";
    private const string PrefabPositionYKey = "PrefabPosY_";

    public Image image; // Reference to the Image component
    public float displayTime = 2.0f; // Time in seconds the image should be displayed

    void Start()
    {
        // Assign the Button's onClick event to call the SpawnPrefab function
        if (spawnButton != null)
        {
            spawnButton.onClick.AddListener(SpawnPrefab);
        }

        // Load previously spawned prefabs
        LoadSpawnedPrefabs();

        // Update the cost text initially
        UpdateCostText();

        image.gameObject.SetActive(false);
    }

    void SpawnPrefab()
    {
        // Check if there are enough resources to spawn the prefab
        if (CanSpawnPrefab())
        {
            // Get the corners of the RectTransform
            Vector3[] corners = new Vector3[4];
            spawnArea.GetWorldCorners(corners);

            // Calculate random position within the RectTransform
            float randomX = Random.Range(corners[0].x, corners[2].x);
            float randomY = Random.Range(corners[0].y, corners[2].y);
            Vector3 randomPosition = new Vector3(randomX, randomY, 0);

            // Convert world position to canvas local position
            Vector2 localPosition;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, randomPosition, canvas.worldCamera, out localPosition);

            // Instantiate the prefab
            GameObject spawnedPrefab = Instantiate(prefabToSpawn, canvas.transform);
            RectTransform spawnedRectTransform = spawnedPrefab.GetComponent<RectTransform>();
            spawnedRectTransform.localPosition = localPosition;

            // Save the position of the spawned prefab
            SaveSpawnedPrefabPosition(localPosition);

            // Decrement the PlayerPrefs values
            DecrementResources();

            // Increment the number of prefabs spawned
            prefabsSpawned++;

            // Update the spawn cost every 5 prefabs
            if (prefabsSpawned % 5 == 0)
            {
                spawnCost += 2;
            }

            // Update the cost text
            UpdateCostText();
        }
        else
        {
            ShowImage();
            message.text = "Not enougn fruits";
        }
    }

    bool CanSpawnPrefab()
    {
        // Check if there are enough resources to spawn the prefab
        return PlayerPrefs.GetInt("LemonCollected", 0) >= spawnCost ||
               PlayerPrefs.GetInt("BananaCollected", 0) >= spawnCost ||
               PlayerPrefs.GetInt("OrangeCollected", 0) >= spawnCost ||
               PlayerPrefs.GetInt("StrawberryCollected", 0) >= spawnCost ||
               PlayerPrefs.GetInt("WatermelonCollected", 0) >= spawnCost ||
               PlayerPrefs.GetInt("MelonCollected", 0) >= spawnCost ||
               PlayerPrefs.GetInt("KiwiCollected", 0) >= spawnCost ||
               PlayerPrefs.GetInt("PineappleCollected", 0) >= spawnCost;
    }

    void DecrementResources()
    {
        // Decrement the PlayerPrefs values by the current spawn cost
        PlayerPrefs.SetInt("LemonCollected", PlayerPrefs.GetInt("LemonCollected") - spawnCost);
        PlayerPrefs.SetInt("BananaCollected", PlayerPrefs.GetInt("BananaCollected") - spawnCost);
        PlayerPrefs.SetInt("OrangeCollected", PlayerPrefs.GetInt("OrangeCollected") - spawnCost);
        PlayerPrefs.SetInt("StrawberryCollected", PlayerPrefs.GetInt("StrawberryCollected") - spawnCost);
        PlayerPrefs.SetInt("WatermelonCollected", PlayerPrefs.GetInt("WatermelonCollected") - spawnCost);
        PlayerPrefs.SetInt("MelonCollected", PlayerPrefs.GetInt("MelonCollected") - spawnCost);
        PlayerPrefs.SetInt("KiwiCollected", PlayerPrefs.GetInt("KiwiCollected") - spawnCost);
        PlayerPrefs.SetInt("PineappleCollected", PlayerPrefs.GetInt("PineappleCollected") - spawnCost);
    }

    void UpdateCostText()
    {
        // Update the TextMeshProUGUI text with the current spawn cost
        costText.text = spawnCost.ToString();
    }

    void SaveSpawnedPrefabPosition(Vector2 position)
    {
        int currentCount = PlayerPrefs.GetInt(SpawnedCountKey, 0) + 1;
        PlayerPrefs.SetFloat(PrefabPositionXKey + currentCount, position.x);
        PlayerPrefs.SetFloat(PrefabPositionYKey + currentCount, position.y);
        PlayerPrefs.SetInt(SpawnedCountKey, currentCount);
        PlayerPrefs.Save();
    }

    void LoadSpawnedPrefabs()
    {
        int count = PlayerPrefs.GetInt(SpawnedCountKey, 0);
        for (int i = 1; i <= count; i++)
        {
            float x = PlayerPrefs.GetFloat(PrefabPositionXKey + i, 0);
            float y = PlayerPrefs.GetFloat(PrefabPositionYKey + i, 0);
            Vector2 position = new Vector2(x, y);

            // Instantiate the prefab
            GameObject spawnedPrefab = Instantiate(prefabToSpawn, canvas.transform);
            RectTransform spawnedRectTransform = spawnedPrefab.GetComponent<RectTransform>();
            spawnedRectTransform.localPosition = position;

            prefabsSpawned = count;  // Restore the prefab count
        }

        // Update the spawn cost based on the loaded prefabs
        spawnCost += (prefabsSpawned / 5) * 2;

        // Update the cost text
        UpdateCostText();
    }

    public void ShowImage()
    {
        // Show the image
        image.gameObject.SetActive(true);
        // Call the HideImage method after displayTime seconds
        Invoke("HideImage", displayTime);
    }

    void HideImage()
    {
        // Hide the image
        image.gameObject.SetActive(false);
    }
}
