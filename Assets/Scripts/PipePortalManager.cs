using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PipePortalManager : MonoBehaviour
{
    [SerializeField] private GameObject _badPortal;

    [SerializeField] private uint extraPortals;
    [SerializeField] private float portalSpacing;
    
    private void Start()
    {
        //Close the hole between pipes
        foreach (Transform t in transform.parent)
        {
            if (t.CompareTag("Pipe"))
                t.position = new Vector3(t.position.x,0,t.position.z);
        }

        for (uint i = 1; i < extraPortals; i++)
        {
            GameObject go = Instantiate(_badPortal, new Vector3(transform.position.x-2.5f,transform.position.y+portalSpacing*i,transform.position.z), Quaternion.identity);
            go.transform.localScale *= 5; // Design flaw, pipe obstacles have a base scale of 5x
            go.transform.parent = transform;
            
            // Spawn a portal on the opposite side
            go = Instantiate(_badPortal, new Vector3(transform.position.x-2.5f,transform.position.y-portalSpacing*i,transform.position.z), Quaternion.identity);
            go.transform.localScale *= 5; // Design flaw, pipe obstacles have a base scale of 5x
            go.transform.parent = transform;
        }
        
        
    }

    //[SerializeField] private GameObject portalPrefab;
    //[SerializeField] private GameObject coinPrefab;

    //private GameObject goodPortal;
    //private GameObject badPortal;

    //public void SetUpPortals(float yOffset)
    //{
    //    // posiciones aleatorias para cada uno de losm portales
    //    float randomY1 = Random.Range(-yOffset, yOffset);
    //    float randomY2 = Random.Range(-yOffset, yOffset);

    //    // creamos los dos portales en posiciones diferentes
    //    goodPortal = Instantiate(portalPrefab, new Vector3(transform.position.x, randomY1, 0), Quaternion.identity, transform);
    //    badPortal = Instantiate(portalPrefab, new Vector3(transform.position.x, randomY2, 0), Quaternion.identity, transform);

    //    // le anadimos moneda al portal bueno
    //    GameObject coin = Instantiate(coinPrefab, goodPortal.transform.position, Quaternion.identity, goodPortal.transform);

    //    //Anadir muerte de player cuando pasa por portal malo, collider q haga de trigger para evento OnPlayerDeath?
    //}
}