using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Oscillator : MonoBehaviour
{
    private float timeOffset;
    public float speed = 2;
    public float amplitude = 5;

    private void Start()
    {
        timeOffset = Random.Range(0f, 1f);
    }

    private void FixedUpdate()
    {
        Vector3 pos = transform.position;
        pos.y = (Mathf.PingPong((Time.time+timeOffset)*speed,  amplitude))-(amplitude/2);
        transform.position = pos;
    }
}