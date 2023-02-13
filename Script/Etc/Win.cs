using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Win : MonoBehaviour
{
    private PlayerManager playerManager;
    private GameStopwatch gameStopwatch;
    [SerializeField] private TMP_Text minutesText;
    [SerializeField] private TMP_Text secondsText;
    void Start()
    {
        playerManager = GameObject.FindObjectOfType<PlayerManager>();
        gameStopwatch = GameObject.FindObjectOfType<GameStopwatch>();
        gameStopwatch.isRunning = false;
        minutesText.text = gameStopwatch.GetMinutes().ToString("F0");
        secondsText.text = gameStopwatch.GetSeconds().ToString("F0");
        playerManager.PlayerMove(0);
        Invoke("Credits",5f);
    }

    void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
}
