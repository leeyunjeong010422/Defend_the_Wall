using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] monsterPrefabs;
    [SerializeField] private int numberOfMonsters = 20; 
    [SerializeField] private float spawnRadius = 100f;

    private HashSet<Vector3> spawnPositions = new HashSet<Vector3>();

    private void Start()
    {
        SpawnMonsters();
    }

    private void SpawnMonsters()
    {
        while (spawnPositions.Count < numberOfMonsters)
        {
            Vector3 spawnPosition = GetRandomNavMeshPosition();
            if (spawnPosition != Vector3.zero && !spawnPositions.Contains(spawnPosition))
            {
                int randomIndex = Random.Range(0, monsterPrefabs.Length);
                GameObject selectedMonster = monsterPrefabs[randomIndex];
                Instantiate(selectedMonster, spawnPosition, Quaternion.identity);
                spawnPositions.Add(spawnPosition);
            }
        }
    }

    private Vector3 GetRandomNavMeshPosition()
    {
        Vector3 randomPosition = Random.insideUnitSphere * spawnRadius;
        randomPosition.y = 0;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPosition, out hit, spawnRadius, NavMesh.AllAreas))
        {
            return hit.position;
        }

        return Vector3.zero;
    }
}
