using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    [SerializeField]
    int timeToEnd;
    bool isGamePaused = false;

    private void Start()
    {
        if (gameManager == null)
            gameManager = this;

        if (timeToEnd <= 0)
            timeToEnd = 100;
        InvokeRepeating("Stopper", 2, 1);
    }

    void Stopper()
    {
        timeToEnd--;
        Debug.Log($"Time: {timeToEnd}s");
    }

    private void Update()
    {
        PauseCheck();
    }

    void PauseCheck()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isGamePaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        Debug.Log("Game Paused");
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void ResumeGame()
    {
        Debug.Log("Game Resumed");
        Time.timeScale = 1f;
        isGamePaused = false;
    }
}
