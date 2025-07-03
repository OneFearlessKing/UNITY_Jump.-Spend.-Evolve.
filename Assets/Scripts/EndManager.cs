using UnityEngine;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour
{
    public GameObject endScreen;
    public PlayerController playerControllerScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        endScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.end == true)
        {
            endScreen.SetActive(true);
        }
    }

    public void RestartGame()
    {
        Debug.Log("Restarting...");
        Time.timeScale = 1f;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
