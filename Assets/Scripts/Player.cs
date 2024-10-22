using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxHP = 100;
    private int currentHP;

    public Slider hpBar;

    private void Start()
    {
        SoundManager.Instance.SetStartBGM();
        hpBar = GameObject.Find("Player_HP").GetComponent<Slider>();
        hpBar.maxValue = maxHP;
        currentHP = maxHP;
        UpdateHPBar();
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        UpdateHPBar();

        if (currentHP <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    private void UpdateHPBar()
    {
        if (hpBar != null)
        {
            hpBar.value = currentHP;
        }
    }
}
