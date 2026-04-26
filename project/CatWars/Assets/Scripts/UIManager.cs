using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header("Screens")]
    public GameObject startScreen;
    public GameObject playerUI;
    public GameObject gameOverScreen;
    public GameObject waveCompleteScreen;

    [Header("Player UI")]
    public Slider hpBar;
    public TextMeshProUGUI hpCounter;
    public TextMeshProUGUI killCounter;

    private int kills = 0;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        ShowStartScreen();
    }

    public void ShowStartScreen()
    {
        startScreen.SetActive(true);
        playerUI.SetActive(false);
        gameOverScreen.SetActive(false);
        waveCompleteScreen.SetActive(false);
    }

    public void StartGame()
    {
        kills = 0;
        UpdateKillCounter();
        startScreen.SetActive(false);
        playerUI.SetActive(true);
        gameOverScreen.SetActive(false);
        waveCompleteScreen.SetActive(false);

        FindObjectOfType<Spawnmanager>().startWave();
    }

    public void ShowGameOver()
    {
        playerUI.SetActive(false);
        gameOverScreen.SetActive(true);
    }

    public void ShowWaveComplete()
    {
        waveCompleteScreen.SetActive(true);
    }

    public void NextWave()
    {
        waveCompleteScreen.SetActive(false);
        Spawnmanager sm = FindObjectOfType<Spawnmanager>();
        sm.increaseDifficulty();
        sm.startWave();
    }

    public void UpdateHp(float current, float max)
    {
        if (hpBar != null)
        {
            hpBar.value = current / max;
        }
        if (hpCounter != null)
        {
            hpCounter.text = Mathf.CeilToInt(current) + " / " + Mathf.CeilToInt(max);
        }
    }

    public void RegisterKill()
    {
        kills++;
        UpdateKillCounter();
    }

    private void UpdateKillCounter()
    {
        if (killCounter != null)
            killCounter.text = "Kills: " + kills;
    }
}
