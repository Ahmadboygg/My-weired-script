using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverPanel;
    public void Retry()
    {
        SceneManager.LoadScene("Stage_1");
        gameOverPanel.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        gameOverPanel.SetActive(false);
    }
}
