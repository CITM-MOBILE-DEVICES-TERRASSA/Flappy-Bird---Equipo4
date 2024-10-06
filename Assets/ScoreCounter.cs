using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private Text text;
    
    void Awake()
    {
        GameManager.OnGameStart += InitializeScore;
        GameManager.OnScoreChange += SetScore;
    }
    
    private void OnDestroy()
    {
        GameManager.OnGameStart -= InitializeScore;
        GameManager.OnScoreChange -= SetScore;
    }

    void InitializeScore() => text.text = "0";
    
    void SetScore(int score)
    {
        text.text = score.ToString();
    }
}
