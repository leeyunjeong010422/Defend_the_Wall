using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    [SerializeField] TextMeshProUGUI scoreText;

    private bool isScoring = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void StartScoreTracking()
    {
        isScoring = true;
    }

    public void UpdateScore(int score)
    {
        if (isScoring)
        {
            scoreText.text = "Á¡¼ö: " + score;

            if (score == 10)
            {
                scoreText.color = Color.red;
                SoundManager.Instance.PlayScore_10Sound();
            }
            else
            {
                scoreText.color = Color.white;
            }
        }
    }
}
