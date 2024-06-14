using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSound : MonoBehaviour
{
    private AudioSource m_AudioSource;
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            m_AudioSource.Play();
        }
    }
}
