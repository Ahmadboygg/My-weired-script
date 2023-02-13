using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausedMenu : MonoBehaviour
{
    [SerializeField] private GameObject pausedPanel;
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private GameStopwatch gameStopwatch;
    private bool isPaused = false;

    void Start()
    {
        playerManager = GameObject.FindObjectOfType<PlayerManager>();
        gameStopwatch = GameObject.FindObjectOfType<GameStopwatch>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }
    public void Resume()
    {
        pausedPanel.SetActive(false);
        isPaused = false;
        playerManager.PlayerMove(playerManager.movementSpeed);
        playerManager.enabled = true;
        gameStopwatch.isRunning = true;
    }

    public void Retry()
    {
        SceneManager.LoadScene("Stage_1");
    }

    private void Paused()
    {
        pausedPanel.SetActive(true);
        isPaused = true;
        playerManager.PlayerMove(0);
        playerManager.enabled = false;
        gameStopwatch.isRunning = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
