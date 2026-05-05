using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public Button returnBtn;

    void Start()
    {
        returnBtn.onClick.AddListener(GoHome);
    }

    void GoHome()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartScreen");
    }
}
