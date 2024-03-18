using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HernandoMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Animator anim_;
    private Rigidbody2D rb;
    private Hernando hernando;

    private float mx;

    private void Start()
    {
        anim_ = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        hernando = GetComponent<Hernando>();
    }

    private void Update()
    {
        mx = Input.GetAxisRaw("Horizontal");

        if (hernando.jordans)
        {
            speed = 8f;
        }

        anim_.SetFloat("running", speed);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(mx, 0f).normalized * speed;
    }
}
