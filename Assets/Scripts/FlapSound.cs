using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlapSound : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _flapSound;
    private void Start()
    {
        _audioSource = gameObject.AddComponent<AudioSource>();
        _audioSource.clip = _flapSound;

        PlayerController.OnJumpButtonDown += _audioSource.Play;
    }

    void OnDestroy()
    {
        PlayerController.OnJumpButtonDown -= _audioSource.Play;
    }
}
