using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnds : MonoBehaviour
{
    [SerializeField] private PlayerEvents playerEvents;
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject Winer;
    [SerializeField] GameObject startGame;

    private void Start()
    {
        playerEvents.OnGameOver += GameOver;
        playerEvents.OnWin += WinnerWinnerChickenDinner;
    }

    private void GameOver ()
    {
        Time.timeScale = 0;
        gameOver.SetActive(true);
    }

    private void WinnerWinnerChickenDinner()
    {
        Time.timeScale = 0;
        Winer.SetActive(true);
    }
}
