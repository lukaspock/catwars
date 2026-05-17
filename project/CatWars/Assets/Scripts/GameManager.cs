
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject helpUi;
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
    public Button sniperButton;
    public Button rocketLauncherButton;

    private WeaponType weaponType;
    public TMP_Text playerHP;
    public TMP_Text waveCounter;
    public bool gameIsOver = false;
    public Button gameOverRestartButton;
    public TMP_Text goldText;
    public TMP_Text killCountWaveOver;
    public TMP_Text killCountGameOver;
    string path;
    public TMP_Text highScoreCounter;

    public Button increaseHpButton;
    public Button increaseSpeedButton;
    public Button healButton;

    private bool helpActive = false;
    private bool mainMenuActive = true;
    private bool gamePaused = false;


    public GameObject playerUpgradeUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // sets the path for the score file to be saved
        path = Path.Combine(Application.persistentDataPath, "scores.txt");
        lockCursor(false);
        Debug.Log("GAME STARTED");
        enableAll(false);
        disableUI();
        startMenu.SetActive(true);  // Show start menu
        highScoreCounter.text = "High Score: " + GetHighscore();
        startButton.onClick.AddListener(StartGame);
        nextWaveButton.onClick.AddListener(StartNextWave);
        returnButton.onClick.AddListener(Restart);
        gameOverRestartButton.onClick.AddListener(Restart);

        mainMenuActive = true;
        helpActive = false;

        increaseHpButton.onClick.AddListener(() =>
        {
            playerBehaviour.IncreaseMaxHp(10);
            spawnmanger.shopActive = false;
            spawnmanger.waveComplete = true;
            UpdateHealthUI(playerBehaviour.currentHp, playerBehaviour.maxHp);

        });

        increaseSpeedButton.onClick.AddListener(() =>
        {
            playerBehaviour.IncreaseSpeed(1);
            spawnmanger.shopActive = false;
            spawnmanger.waveComplete = true;

        });

        healButton.onClick.AddListener(() =>
        {
            playerBehaviour.Heal();
            spawnmanger.shopActive = false;
            spawnmanger.waveComplete = true;
            UpdateHealthUI(playerBehaviour.currentHp, playerBehaviour.maxHp);
        });


    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            togglePause();
        }

        if (gamePaused)
        {

        }
        if (helpActive)
        {
            disableUI();
            enableAll(false);
            helpUi.SetActive(true);
            lockCursor(false);
        }
        if (spawnmanger.shopActive)
        {
            lockCursor(false);
            disableUI();
            playerUpgradeUI.SetActive(true);
            enableAll(false);
        }
        if (spawnmanger.waveComplete)
        {
            disableUI();
            killCountWaveOver.text = "Kill Count: " + playerBehaviour.getKillCount().ToString();
            waveCompleteMenu.SetActive(true);
            enableAll(false);
            nextWaveButton.gameObject.SetActive(true);
            lockCursor(false);
            updateGoldUI(playerBehaviour.goldCount);
            weaponType = playerBehaviour.weaponType;

            shotgunButton.onClick.RemoveAllListeners();
            gunButton.onClick.RemoveAllListeners();


            if (weaponType == WeaponType.Shotgun)
            {
                int price = playerBehaviour.weaponsDic[WeaponType.Shotgun].prefab.upgradePrice;
                shotgunButton.GetComponentInChildren<TMP_Text>().text = $"Upgrade ({price}g)";
                shotgunButton.interactable = playerBehaviour.goldCount >= price;
                shotgunButton.onClick.AddListener(() =>
                {
                    playerBehaviour.upgradeWeapon();
                    updateGoldUI(playerBehaviour.goldCount);
                });
            }
            else
            {
                int price = playerBehaviour.weaponsDic[WeaponType.Shotgun].prefab.price;
                shotgunButton.GetComponentInChildren<TMP_Text>().text = $"Shotgun ({price}g)";
                shotgunButton.interactable = playerBehaviour.goldCount >= price;
                shotgunButton.onClick.AddListener(() => { playerBehaviour.SwitchWeapon(WeaponType.Shotgun); updateGoldUI(playerBehaviour.goldCount); });
            }

            if (weaponType == WeaponType.Gun)
            {
                int price = playerBehaviour.weaponsDic[WeaponType.Gun].prefab.upgradePrice;
                gunButton.GetComponentInChildren<TMP_Text>().text = $"Upgrade ({price}g)";
                gunButton.interactable = playerBehaviour.goldCount >= price;
                gunButton.onClick.AddListener(() => { playerBehaviour.upgradeWeapon(); updateGoldUI(playerBehaviour.goldCount); });
            }
            else
            {
                gunButton.GetComponentInChildren<TMP_Text>().text = "Gun (free)";
                gunButton.interactable = true;
                gunButton.onClick.AddListener(() => { playerBehaviour.SwitchWeapon(WeaponType.Gun); updateGoldUI(playerBehaviour.goldCount); });
            }

            if (weaponType == WeaponType.Sniper)
            {
                int price = playerBehaviour.weaponsDic[WeaponType.Sniper].prefab.upgradePrice;
                gunButton.GetComponentInChildren<TMP_Text>().text = $"Upgrade ({price}g)";
                gunButton.interactable = playerBehaviour.goldCount >= price;
                gunButton.onClick.AddListener(() =>
                {
                    playerBehaviour.upgradeWeapon();
                    updateGoldUI(playerBehaviour.goldCount);
                });
            }
            else
            {
                int price = playerBehaviour.weaponsDic[WeaponType.Sniper].prefab.price;
                sniperButton.GetComponentInChildren<TMP_Text>().text = $"Sniper ({price}g)";
                sniperButton.interactable = playerBehaviour.goldCount >= price;
                sniperButton.onClick.AddListener(() =>
                {
                    playerBehaviour.SwitchWeapon(WeaponType.Sniper);
                    updateGoldUI(playerBehaviour.goldCount);
                });
            }


            if (weaponType == WeaponType.RocketLauncher)
            {
                int price = playerBehaviour.weaponsDic[WeaponType.RocketLauncher].prefab.upgradePrice;
                rocketLauncherButton.GetComponentInChildren<TMP_Text>().text = $"Upgrade ({price}g)";
                rocketLauncherButton.interactable = playerBehaviour.goldCount >= price;
                rocketLauncherButton.onClick.AddListener(() =>
                {
                    playerBehaviour.upgradeWeapon();
                    updateGoldUI(playerBehaviour.goldCount);
                });
            }
            else
            {
                int price = playerBehaviour.weaponsDic[WeaponType.RocketLauncher].prefab.price;
                rocketLauncherButton.GetComponentInChildren<TMP_Text>().text = $"RocketLauncher ({price}g)";
                rocketLauncherButton.interactable = playerBehaviour.goldCount >= price;
                rocketLauncherButton.onClick.AddListener(() =>
                {
                    playerBehaviour.SwitchWeapon(WeaponType.RocketLauncher);
                    updateGoldUI(playerBehaviour.goldCount);
                });
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

    //disables all gamobjects, saves highscore and resets scene
    public void Restart()
    {
        enableAll(false);
        lockCursor(false);
        saveScore(playerBehaviour.getKillCount());
        highScoreCounter.text = "HighScore: " + GetHighscore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }


    // starts the game (ain't no way)
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


    // disables all UI
    public void disableUI()
    {
        playerUpgradeUI.SetActive(false);
        startMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        waveCompleteMenu.SetActive(false);
        PlayerUI.SetActive(false);
        helpUi.SetActive(false);
    }

    // enables or disables all gameobjects (in the list)
    public void enableAll(bool enable)
    {
        foreach (var obj in objectsToEnable)
        {
            obj.SetActive(enable);
        }
    }

    // locks / unlocks the cursor and makes it visible / invis
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

    // updates the health ui

    public void UpdateHealthUI(float newHealth, float maxHealth)
    {
        playerHP.text = "HP: " + newHealth + "/" + maxHealth;
    }


    // updates the wave counter
    public void UpdateWaveCounterUI(float newWave)
    {
        waveCounter.text = "Wave: " + newWave;
    }

    // shows gameover menu and stops the game
    public void GameOver()
    {
        disableUI();
        killCountGameOver.text = "Kill Count: " + playerBehaviour.getKillCount().ToString();
        gameOverMenu.SetActive(true);               // Show game over menu
        enableAll(false);   // Disable all game objects
        lockCursor(false);
        gameIsOver = true;
    }

    // updates gold ui

    public void updateGoldUI(float gold)
    {
        goldText.text = "Gold: " + gold;
    }

    // save the score to the score file to the path from the start
    public void saveScore(int score)
    {
        File.AppendAllText(path, score + "\n");
    }

    // reads the score.txt file from start and gets the highest score
    public int GetHighscore()
    {
        if (!File.Exists(path))
            return 0;

        string[] lines = File.ReadAllLines(path);

        int highest = 0;

        foreach (string line in lines)
        {
            if (int.TryParse(line, out int score))
            {
                if (score > highest)
                {
                    highest = score;
                }
            }
        }

        return highest;
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void activateHelpUI()
    {
        helpActive = true;

    }

    public void disableHelpUI()
    {
        disableUI();
        enableAll(false);
        startMenu.SetActive(true);
        helpActive = false;
    }

    public void togglePause()
    {
        gamePaused = !gamePaused;
        lockCursor(gamePaused);
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1; // Resume
                                // pauseMenuUI.SetActive(false);
        }
        else
        {
            Time.timeScale = 0; // Freeze
                                // pauseMenuUI.SetActive(true);
        }
    }

}
