using Unity.VisualScripting;
using UnityEngine;

public class OinkyMovement : MonoBehaviour
{
    private float speed = 7.5f;
    private float distance = 17.0f;
    private float startX;
    private AudioSource sound;

    void Start()
    {
        sound = GetComponent<AudioSource>();

        this.gameObject.SetActive(false);

        startX = transform.position.x;

        int oinkyPurchased = PlayerPrefs.GetInt("OinkyPurchased", 0);

        if (oinkyPurchased == 1)
        {
            this.gameObject.SetActive(true);   
        }
    }

    void Update()
    {
        float newX = startX + Mathf.PingPong(Time.time * speed, distance) - (distance / 2.0f);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Lemon") ||
            collision.gameObject.CompareTag("Kiwi") ||
            collision.gameObject.CompareTag("Strawberry") ||
            collision.gameObject.CompareTag("Melon") ||
            collision.gameObject.CompareTag("Watermelon") ||
            collision.gameObject.CompareTag("Banana") ||
            collision.gameObject.CompareTag("Orange") ||
            collision.gameObject.CompareTag("Pineapple")
           )
        {
            sound.Play();
        }
    }
}