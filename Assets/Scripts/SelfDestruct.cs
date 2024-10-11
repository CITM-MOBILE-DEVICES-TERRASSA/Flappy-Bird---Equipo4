using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] private float timeUntilDestruction = 1.0F;
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(DestroySelf), timeUntilDestruction);
    }


    private void DestroySelf() => Destroy(gameObject);
}
