using UnityEngine;
using TMPro;

public class HpBar : MonoBehaviour
{
    public TMP_Text hpText;
    public PlayerBehaviour player;

    void Start()
    {
        
    }

    void Update()
    {
        hpText.text = "Hp: " + player.getCurrentHp();
    }
}