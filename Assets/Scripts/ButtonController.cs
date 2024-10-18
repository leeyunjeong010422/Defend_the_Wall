using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] TrainingEnemySpawner enemySpawner; // 적 스포너 참조
    [SerializeField] Button spawnButton;
    [SerializeField] Button targetButton;

    private void Start()
    {
        if (spawnButton != null)
        {
            spawnButton.onClick.AddListener(StartSpawningEnemies);
        }

        if (targetButton != null)
        {
            targetButton.onClick.AddListener(StartScore);
        }
    }

    private void StartSpawningEnemies()
    {
        if (enemySpawner != null)
        {
            enemySpawner.StartSpawning(); // 적 스폰 시작
        }
    }

    private void StartScore()
    {
        ScoreManager.Instance.StartScoreTracking();
    }
}
