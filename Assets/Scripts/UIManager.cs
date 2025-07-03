using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject titleScreen;
    public PlayerController playerController;

    public void StartGame()
    {
        titleScreen.SetActive(false); // Hide UI
        playerController.StartRunning(); // Start the game
    }
}