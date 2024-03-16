using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class FruitSpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private List<GameObject> fruits = new List<GameObject>();
    [SerializeField] private List<Transform> spawnPoints = new List<Transform>();

    [Header("Attributes")]
    [SerializeField] private float spawnSpeed = 1f;
    
    public int totalSpawned = 0;

    private void Start()
    {
        spawnSpeed = 5f;
        StartCoroutine(SpawnFruit());
    }

    IEnumerator SpawnFruit()
    {
        while (true)
        {
            GameObject fruit = fruits[Random.Range(0, fruits.Count)];
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];

            Instantiate(fruit, spawnPoint.position, spawnPoint.rotation);
            totalSpawned++;

            if (totalSpawned % 15 == 0)
            {
                spawnSpeed -= 0.2f;

                if(spawnSpeed < 0.5f)
                {
                    spawnSpeed = 0.5f;
                }
            }

            yield return new WaitForSeconds(spawnSpeed);
        }
    }
}
