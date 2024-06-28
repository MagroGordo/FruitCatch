using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HernandoMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Animator anim_;
    private Rigidbody2D rb;
    private UpgradeManager upgrade_;
    private AudioSource sound;

    private float mx;

    private void Start()
    {
        anim_ = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sound = GetComponent<AudioSource>();

        int upgradePurchasedValue = PlayerPrefs.GetInt("JordansPurchased", 0);

        if (upgradePurchasedValue == 1)
        {
            speed = 10f;
        }
    }

    private void Update()
    {
        mx = Input.GetAxisRaw("Horizontal") * speed;
        anim_.SetFloat("speed", Mathf.Abs(mx));

        if (mx < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

        if (mx > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(mx, 0f).normalized * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fruit"))
        {
            sound.Play();
        }
    }
}
