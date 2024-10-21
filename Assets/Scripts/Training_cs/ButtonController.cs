using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    [SerializeField] TrainingEnemySpawner enemySpawner;
    [SerializeField] Button spawnButton;
    [SerializeField] Button targetButton;
    [SerializeField] Button gameStartButton;

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

        if (gameStartButton != null)
        {
            gameStartButton.onClick.AddListener(() => GoToInGame("Game"));
        }
    }

    private void StartSpawningEnemies()
    {
        if (enemySpawner != null)
        {
            enemySpawner.StartSpawning();
        }
    }

    private void StartScore()
    {
        ScoreManager.Instance.StartScoreTracking();
    }

    public void GoToInGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
