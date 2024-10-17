using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingEnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] int poolSize = 5;
    [SerializeField] float spawnInterval = 2f;
    [SerializeField] Vector2 xRange;
    [SerializeField] float yPosition = 14.08f;
    [SerializeField] Vector2 zRange;

    private List<GameObject> enemyPool;
    private float timer;

    private void Start()
    {
        enemyPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.SetActive(false);
            enemy.transform.parent = transform;
            enemyPool.Add(enemy);
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >=  spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    private void SpawnEnemy()
    {
        foreach (GameObject enemy in enemyPool)
        {
            if (!enemy.activeInHierarchy)
            {
                //랜덤 위치 계산
                float randomX = Random.Range(xRange.x, xRange.y);
                float randomZ = Random.Range(zRange.x, zRange.y);
                Vector3 spawnPosition = new Vector3(randomX, yPosition, randomZ);

                //적 활성화 및 위치 설정
                enemy.transform.position = spawnPosition;
                enemy.SetActive(true);
                break;
            }
        }
    }

    public void ReturnEnemyToPool(GameObject enemy)
    {
        enemy.SetActive(false);
    }
}
