using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject startGameView;
    [SerializeField] private GameObject endGameView;
    [SerializeField] private GameObject winGameView;

    private void Awake()
    {
        Time.timeScale = 0;
        startGameView.SetActive(true);
        endGameView.SetActive(false);
        winGameView.SetActive(false);
    }

    public void StartingGame ()
    {
        Time.timeScale = 1;
        startGameView.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
