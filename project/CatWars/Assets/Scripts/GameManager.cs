using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Spawnmanager spawnmanger;
    public Button startButton;
    public GameObject startMenu;
    public GameObject[] objectsToEnable;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 0f;                          // Freeze everything

        foreach (var obj in objectsToEnable)
        {
            obj.SetActive(false);
        }
        // Disable all game objects
        startMenu.SetActive(true);                  // Show start menu
        startButton.onClick.AddListener(StartGame);   // Wire up button
    }

    public void ButtonOnclick()
    {
        Debug.Log("Button clicked");
    }

    public void StartGame()
    {
        startMenu.SetActive(false);                 // Hide UI

        foreach (var obj in objectsToEnable)
        {
            obj.SetActive(true);
        }
        // Enable all game objects

        Time.timeScale = 1f;                          // Unfreeze
    }
}
