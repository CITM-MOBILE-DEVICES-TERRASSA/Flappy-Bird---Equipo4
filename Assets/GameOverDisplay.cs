using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameOverDisplay : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    
    // Start is called before the first frame update
    void Awake()
    {
        GameManager.OnGameEnd += DisplayPanel;
        GameManager.OnGameStart += HidePanel;
    }

    private void OnDestroy()
    {
        GameManager.OnGameEnd -= DisplayPanel;
        GameManager.OnGameStart -= HidePanel;
    }

    void DisplayPanel()
    {
        panel.SetActive(true);
    }

    void HidePanel()
    {
        panel.SetActive(false);
    }
}
