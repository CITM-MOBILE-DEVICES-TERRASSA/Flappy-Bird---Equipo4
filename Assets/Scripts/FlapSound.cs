using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlapSound : MonoBehaviour
{
    private AudioSource _audioSource;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _audioSource.Play();
        }
    }
}
