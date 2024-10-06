using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static event Action OnGameStart;
    public static event Action OnGameEnd;
    public static event Action<int> OnScoreChange;

    private int score = 0;
    
    private bool isGameOver = false;
    private float timer = 0f;
    
    void Awake()
    {
        PlayerController.OnPointObtained += IncreaseScore;
        PlayerController.OnPlayerDeath += GameOver;
    }

    void Start()
    {
        OnGameStart?.Invoke();
    }

    void Update()
    {
        if (isGameOver)
        {
            // The timer prevents instantly starting over
            if (timer > 1.0F && Input.GetButtonDown("Jump"))
            {
                //Reload scene to play again (don't do this on heavy games resource-wise)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            timer += Time.deltaTime;
        }
    }

    private void OnDestroy()
    {
        PlayerController.OnPointObtained -= IncreaseScore;
        PlayerController.OnPlayerDeath -= GameOver;
    }

    void IncreaseScore()
    {
        score++;
        OnScoreChange?.Invoke(score);
    }

    void GameOver()
    {
        isGameOver = true;
        OnGameEnd?.Invoke();
    }
}
