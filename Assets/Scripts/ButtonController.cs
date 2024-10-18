using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] TrainingEnemySpawner enemySpawner; // �� ������ ����
    [SerializeField] Button spawnButton;

    private void Start()
    {
        if (spawnButton != null)
        {
            spawnButton.onClick.AddListener(StartSpawningEnemies);
        }
    }

    private void StartSpawningEnemies()
    {
        if (enemySpawner != null)
        {
            enemySpawner.StartSpawning(); // �� ���� ����
        }
    }
}
