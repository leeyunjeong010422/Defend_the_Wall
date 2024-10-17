using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingEnemyController : MonoBehaviour
{
    private TrainingEnemySpawner spawner;

    private void Start()
    {
        spawner = FindObjectOfType<TrainingEnemySpawner>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            spawner.ReturnEnemyToPool(gameObject);
        }
    }
}
