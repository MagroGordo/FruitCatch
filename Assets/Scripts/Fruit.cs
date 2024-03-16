using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public float fruitFallSpeed = 0.02f;

    private Hernando hernando;
    private FruitSpawner spawner;

    private void Awake()
    {
        hernando = FindObjectOfType<Hernando>();
        spawner = FindObjectOfType<FruitSpawner>();
    }

    private void Update()
    {
        if (spawner.totalSpawned % 15 != 0)
            return;
        else
            fruitFallSpeed += 0.02f;
    }

    void FixedUpdate()
    {
        transform.Translate(0, -fruitFallSpeed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hernando"))
        {
            Destroy(this.gameObject);

            if (CompareTag("Lemon"))
            {
                hernando.lemonCount++;
            }
            if (CompareTag("Strawberry"))
            {
                hernando.strawberryCount++;
            }
            if (CompareTag("Melon"))
            {
                hernando.melonCount++;
            }
            if (CompareTag("Watermelon"))
            {
                hernando.watermelonCount++;
            }
            if (CompareTag("Pineapple"))
            {
                hernando.pineappleCount++;
            }
            if (CompareTag("Kiwi"))
            {
                hernando.kiwiCount++;
            }
            if (CompareTag("Banana"))
            {
                hernando.bananaCount++;
            }
            if (CompareTag("Orange"))
            {
                hernando.orangeCount++;
            }
        }

        if (collision.gameObject.CompareTag("Barrier"))
        {
            Destroy(this.gameObject);

            if (CompareTag("Lemon"))
            {
                hernando.lemonCount--;
            }
            if (CompareTag("Strawberry"))
            {
                hernando.strawberryCount--;
            }
            if (CompareTag("Melon"))
            {
                hernando.melonCount--;
            }
            if (CompareTag("Watermelon"))
            {
                hernando.watermelonCount--;
            }
            if (CompareTag("Pineapple"))
            {
                hernando.pineappleCount--;
            }
            if (CompareTag("Kiwi"))
            {
                hernando.kiwiCount--;
            }
            if (CompareTag("Banana"))
            {
                hernando.bananaCount--;
            }
            if (CompareTag("Orange"))
            {
                hernando.orangeCount--;
            }
        }
    }

    public void IncreaseFallSpeed(float increaseSpeed)
    {
        fruitFallSpeed += increaseSpeed;
    }
}
