using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIRectTransformSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn;    
    public RectTransform spawnArea;     
    public Button spawnButton;         
    public Canvas canvas;                
    public TextMeshProUGUI costText;    
    public TextMeshProUGUI message;

    private int prefabsSpawned = 0;     
    private int spawnCost = 1;

    private AudioSource sound;

    private const string SpawnedCountKey = "PrefabsSpawned";
    private const string PrefabPositionXKey = "PrefabPosX_";
    private const string PrefabPositionYKey = "PrefabPosY_";

    public Image image;
    public float displayTime = 2.0f;

    void Start()
    {
        sound = GetComponent<AudioSource>();

        if (spawnButton != null)
        {
            spawnButton.onClick.AddListener(SpawnPrefab);
        }

        LoadSpawnedPrefabs();

        UpdateCostText();

        image.gameObject.SetActive(false);
    }

    void SpawnPrefab()
    {
        if (CanSpawnPrefab())
        {
            sound.Play();

            Vector3[] corners = new Vector3[4];
            spawnArea.GetWorldCorners(corners);

            float randomX = Random.Range(corners[0].x, corners[2].x);
            float randomY = Random.Range(corners[0].y, corners[2].y);
            Vector3 randomPosition = new Vector3(randomX, randomY, 0);

            Vector2 localPosition;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, randomPosition, canvas.worldCamera, out localPosition);

            GameObject spawnedPrefab = Instantiate(prefabToSpawn, canvas.transform);
            RectTransform spawnedRectTransform = spawnedPrefab.GetComponent<RectTransform>();
            spawnedRectTransform.localPosition = localPosition;

            SaveSpawnedPrefabPosition(localPosition);

            DecrementResources();

            prefabsSpawned++;

            if (prefabsSpawned % 5 == 0)
            {
                spawnCost += 2;
            }

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

            GameObject spawnedPrefab = Instantiate(prefabToSpawn, canvas.transform);
            RectTransform spawnedRectTransform = spawnedPrefab.GetComponent<RectTransform>();
            spawnedRectTransform.localPosition = position;

            prefabsSpawned = count;
        }

        spawnCost += (prefabsSpawned / 5) * 2;

        UpdateCostText();
    }

    public void ShowImage()
    {
        image.gameObject.SetActive(true);
        Invoke("HideImage", displayTime);
    }

    void HideImage()
    {
        image.gameObject.SetActive(false);
    }
}
