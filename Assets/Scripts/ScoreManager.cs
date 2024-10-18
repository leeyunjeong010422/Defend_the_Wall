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
        scoreText.text = "점수: " + score;

        if (score == 10)
        {
            scoreText.color = Color.red; // 빨간색
        }
        else
        {
            scoreText.color = Color.white; // 기본 색상으로 변경 (예: 흰색)
        }
    }
}
