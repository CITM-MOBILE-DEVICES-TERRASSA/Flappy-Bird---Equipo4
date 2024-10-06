using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    [SerializeField] private Vector2 speed;

    void FixedUpdate()
    {
        transform.Translate(speed);
    }
}
