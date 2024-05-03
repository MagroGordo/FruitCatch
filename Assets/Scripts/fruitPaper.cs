using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class fruitPaper : MonoBehaviour
{
    [SerializeField] private Animator anim_;

    private bool hidden;

    private void Start()
    {
        anim_ = GetComponent<Animator>();   
        hidden = anim_.GetBool("hidden");
    }
}
