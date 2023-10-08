using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    [SerializeField]
    int timeToEnd;
    bool isGamePaused = false, 
        endGame = false, 
        win = false;
    public int points = 0;
    public int redKey = 0,
        greenKey = 0,
        goldKey = 0;

    private void Start()
    {
        if (gameManager == null)
            gameManager = this;

        if (timeToEnd <= 0)
            timeToEnd = 5;
        InvokeRepeating("Stopper", 2, 1);
    }

    void Stopper()
    {
        timeToEnd--;
        Debug.Log($"Time: {timeToEnd}s");

        if(timeToEnd <= 0)
        {
            timeToEnd = 0;
            endGame = true;
        }
        if (endGame)
        {
            EndGame();
        }
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

    public void EndGame()
    {
        CancelInvoke("Stopper");
        if (win)
            Debug.Log("You win!");
        else
            Debug.Log("You lose!");
    }

    public void AddPoints(int points)
    {
        this.points += points; //this.points = this.points + points;
    }

    public void AddTime(int addTime)
    {
        timeToEnd += addTime;
    }

    public void FreezeTime(int freezeTime)
    {
        CancelInvoke("Stopper");
        InvokeRepeating("Stopper", freezeTime, 1);
    }

    public void AddKey(KeyColor keyColor)
    {
        if (keyColor == KeyColor.Red)
            redKey++;
        else if (keyColor == KeyColor.Green)
            greenKey++;
        else if (keyColor == KeyColor.Gold)
            goldKey++;
        else
            Debug.LogWarning("Incorrect key!");
    }
}
