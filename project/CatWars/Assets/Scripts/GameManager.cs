using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public PlayerBehaviour playerBehaviour;
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
    private Vector3 spawnPosition = new Vector3(597f, 30.5f, 566f);
    GameObject player;
    public Button shotgunButton;
    public Button gunButton;
    private WeaponType weaponType;
    public TMP_Text playerHP;
    public TMP_Text waveCounter;
    public bool gameIsOver = false;
    public Button gameOverRestartButton;
    public TMP_Text goldText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lockCursor(false);
        Debug.Log("GAME STARTED");
        enableAll(false);
        disableUI();
        startMenu.SetActive(true);                  // Show start menu
        startButton.onClick.AddListener(StartGame);
        nextWaveButton.onClick.AddListener(StartNextWave);
        returnButton.onClick.AddListener(Restart);
        gameOverRestartButton.onClick.AddListener(Restart);
    }

    void Update()
    {
        if (spawnmanger.waveComplete)
        {
            disableUI();
            waveCompleteMenu.SetActive(true);          // Show wave complete menu
            enableAll(false);   // Disable all game objects
            nextWaveButton.gameObject.SetActive(true);
            //Cursor.lockState = CursorLockMode.None;
            lockCursor(false);
            updateGoldUI(playerBehaviour.goldCount);
            weaponType = playerBehaviour.weaponType;

            if (weaponType == WeaponType.Shotgun)
            {
                shotgunButton.GetComponentInChildren<TMP_Text>().text = "Upgrade (1000g)";
                shotgunButton.onClick.AddListener(playerBehaviour.upgradeWeapon);
            }
            else
            {
                shotgunButton.GetComponentInChildren<TMP_Text>().text = "Shotgun (1500g)";
                shotgunButton.onClick.AddListener(playerBehaviour.switchToShotgun);
            }

            if (weaponType == WeaponType.Gun)
            {
                gunButton.GetComponentInChildren<TMP_Text>().text = "Upgrade (500g)";
                gunButton.onClick.AddListener(playerBehaviour.upgradeWeapon);
            }
            else
            {
                gunButton.GetComponentInChildren<TMP_Text>().text = "Gun (free)";
                gunButton.onClick.AddListener(playerBehaviour.switchToPistol);
            }
        }
    }

    public void StartNextWave()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            player.transform.position = spawnPosition; // Reset Player pos
        }

        enableAll(true);
        disableUI();
        PlayerUI.SetActive(true);
        lockCursor(true);
        spawnmanger.continueWaves();

    }

    public void Restart()
    {
        enableAll(false);
        lockCursor(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }



    public void StartGame()
    {
        gameIsOver = false;
        Debug.Log("START GAME PRESSED");
        disableUI();
        PlayerUI.SetActive(true);                  // Show player UI
        // Enable all game objects
        enableAll(true);
        lockCursor(true);
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

    public void lockCursor(bool lockCursor)
    {
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void UpdateHealthUI(float newHealth, float maxHealth)
    {
        playerHP.text = "HP: " + newHealth + "/" + maxHealth;
    }

    public void UpdateWaveCounterUI(float newWave)
    {
        waveCounter.text = "Wave: " + newWave;
    }

    public void GameOver()
    {
        disableUI();
        gameOverMenu.SetActive(true);               // Show game over menu
        enableAll(false);   // Disable all game objects
        lockCursor(false);
        gameIsOver = true;
    }

    public void updateGoldUI(float gold)
    {
        goldText.text = "Gold: " + gold;
    }



}
