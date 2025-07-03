using System;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject pauseButton;
    public PlayerController playerControllerScript;

    void Start()
    {
        pauseScreen.SetActive(false);
        pauseButton.SetActive(false);
    }

    void Update()
    {
        if (playerControllerScript.gameOver == true)
        {
            pauseButton.SetActive(false);
        }
    }

    public void ActivatePauseButton()
    {
        pauseButton.SetActive(true);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseScreen.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
        pauseButton.SetActive(true);
    }
}
