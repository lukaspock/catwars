using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

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
        nextWaveButton.onClick.AddListener(spawnmanger.continueWaves);
    }

    void Update()
    {
       if (spawnmanger.waveComplete)
       {
            disableUI();
            waveCompleteMenu.SetActive(true);          // Show wave complete menu
            enableAll(false);                        // Disable all game objects
        }
    }

    //public void ButtonOnclick()
    //{
    //    Debug.Log("Button clicked");
    //}

    public void StartGame()
    {
        disableUI();
        PlayerUI.SetActive(true);                  // Show player UI

        enableAll(true);

        // Enable all game objects

 
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