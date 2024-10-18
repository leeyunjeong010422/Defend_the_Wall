using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    [SerializeField] TextMeshProUGUI scoreText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "����: " + score;

        if (score == 10)
        {
            scoreText.color = Color.red; // ������
        }
        else
        {
            scoreText.color = Color.white; // �⺻ �������� ���� (��: ���)
        }
    }
}
