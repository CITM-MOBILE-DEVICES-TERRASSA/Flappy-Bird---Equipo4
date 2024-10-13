using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    [SerializeField] private Vector2 speed;

    void Start() => PlayerController.OnPortalEnter += Displacement;
    
    void OnDestroy() => PlayerController.OnPortalEnter -= Displacement;
    
    void FixedUpdate()
    {
        transform.Translate(speed);
    }

    void Displacement(Vector3 displacement)
    {
        transform.position += displacement;
    }
}
