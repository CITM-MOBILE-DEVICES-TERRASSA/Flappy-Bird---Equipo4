using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float impulse = 5;
    [SerializeField] private float rotationPower = 2;
    
    public static event Action OnPlayerDeath;
    public static event Action OnPointObtained;
    public static event Action OnJumpButtonDown;

    [SerializeField] private AudioClip deathClip;
    [SerializeField] AudioClip pointSound_;

    private AudioSource pointSound;
    private AudioSource audioDeath;
    
    
    private Rigidbody2D rb;

    private Renderer visual;

    private bool buttonDown = false;


    DeathEffects deathEffects;


    // Start is called before the first frame update
    void Start()
    {
        deathEffects = GetComponent<DeathEffects>();

        rb = GetComponent<Rigidbody2D>();
        // Rigidbody2D required
        // if preconfigured rigidbody not found create a default one
        if (!rb)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
        }
        
        visual = GetComponentInChildren<SpriteRenderer>();

        audioDeath = gameObject.AddComponent<AudioSource>();

        audioDeath = gameObject.AddComponent<AudioSource>();
        audioDeath.clip = deathClip;
        OnPlayerDeath += audioDeath.Play;

        pointSound = gameObject.AddComponent<AudioSource>();
        pointSound.clip = pointSound_;
        OnPointObtained += pointSound.Play;
    }

    void OnDestroy()
    {
        OnPlayerDeath -= audioDeath.Play;

        OnPointObtained -= pointSound.Play;
    }

    // Update is called once per frame
    void Update()
    {
        buttonDown |= Input.GetButtonDown("Jump");
        
    }

    private void OnPostRender()
    {
        if (!visual.isVisible)
            GameOver();
    }

    void FixedUpdate()
    {
        if (buttonDown)
        {
            rb.velocity = new Vector2(0, impulse);
            OnJumpButtonDown?.Invoke();
            buttonDown = false;
        }

        if (visual)
        {
            Vector2 velocity = rb.velocity;
            visual.transform.rotation = Quaternion.Euler(0f, 0f, velocity.y*rotationPower);    
        }

        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        OnPointObtained?.Invoke();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        deathEffects.DeathEf();
        GameOver(); 
    }

    void GameOver()
    {
       
        audioDeath?.Play();
        OnPlayerDeath?.Invoke();
        Destroy(this); // Destroy just the player controller, bird will fall down by gravity
    }



}
