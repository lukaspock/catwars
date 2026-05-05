using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Spawnmanager spawnmanger;
    public Button startButton;
    public GameObject startMenu;
    public GameObject gameOverMenu;
    public GameObject waveCompleteMenu;
    public GameObject PlayerUI;
    public Button nextWaveButton;
    public Button returnButton;
    public Button shopButton;
    public GameObject[] objectsToEnable;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enableAll(false);
        disableUI();
        startMenu.SetActive(true);                  // Show start menu
        startButton.onClick.AddListener(StartGame);
        nextWaveButton.onClick.AddListener(StartNextWave);
        returnButton.onClick.AddListener(Restart);
    }

    void Update()
    {
       if (spawnmanger.waveComplete)
       {
            disableUI();
            waveCompleteMenu.SetActive(true);          // Show wave complete menu
            enableAll(false);   // Disable all game objects
            nextWaveButton.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void StartNextWave()
    {
        enableAll(true);
        disableUI();
        PlayerUI.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        spawnmanger.continueWaves();

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }



    public void StartGame()
    {
        disableUI();
        PlayerUI.SetActive(true);                  // Show player UI
        // Enable all game objects
        enableAll(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void disableUI()
    {
        startMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        waveCompleteMenu.SetActive(false); 
        PlayerUI.SetActive(false);
    }

    public void enableAll(bool enable) // enables or disables all game objects in the array based on the boolean parameter
    {
        foreach (var obj in objectsToEnable)
        {
            obj.SetActive(enable);
        }
    }


}