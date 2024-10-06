using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pipe;
    
    [SerializeField] private float offsetX;
    
    [SerializeField] private float spawnDelay;

    private void Awake()
    {
        GameManager.OnGameStart += OnGameStart;
        GameManager.OnGameEnd += OnGameOver;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStart -= OnGameStart;
        GameManager.OnGameEnd -= OnGameOver;
    }


    void OnGameStart() => InvokeRepeating(nameof(SpawnPipe), 0, spawnDelay);
    
    void OnGameOver() => CancelInvoke(nameof(SpawnPipe));

    void SpawnPipe()
    {
        if (pipe)
        {
            float y = Random.Range(-2.0f, 2.0f);
            Instantiate(pipe, new Vector3(offsetX, y, 0), Quaternion.identity);
        }
    }
}
