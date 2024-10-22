using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Wall_HP : MonoBehaviour
{
    public int maxHP = 100;
    private int currentHP;

    public Slider hpBar;

    private void Start()
    {
        hpBar = GameObject.Find("Wall_HP").GetComponent<Slider>();
        hpBar.maxValue = maxHP;
        currentHP = maxHP;
        UpdateHPBar();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Monster"))
        {
            SoundManager.Instance.PlayWallBreak();
            TakeDamage(5);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        UpdateHPBar();

        if (currentHP <= 0)
        {
            SoundManager.Instance.PlayWallCollapse();
            SoundManager.Instance.StopBGM();
            gameObject.SetActive(false);
            hpBar.gameObject.SetActive(false);
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