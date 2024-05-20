using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class fruitPaper : MonoBehaviour
{
    [SerializeField] private GameObject paper;
    [SerializeField] private TextMeshProUGUI text;

    private bool visible;

    private void Start()
    {
        paper = GameObject.Find("Fruit Count");
        text = FindObjectOfType<TextMeshProUGUI>();
    }

    private void Update()
    {
        text.text = "lemon x17\n" +
            "banana x20\n" +
            "ornage x 1\n" +
            "strawberry x6\n" +
            "watermelon x9\n" +
            "melon x5\n" +
            "kiwi x0\n" +
            "pineapple x8";

        if (Input.GetKeyDown(KeyCode.Space))
        {
            visible = !visible;
            paper.SetActive(visible);
        }
    }
}
