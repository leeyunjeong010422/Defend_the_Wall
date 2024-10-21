using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] monsterPrefabs;
    [SerializeField] int numberOfMonsters;
    [SerializeField] float spawnRadius = 10f;

    private void Start()
    {
        SpawnMonsters();
    }

    private void SpawnMonsters()
    {
        for (int i = 0; i < numberOfMonsters; i++)
        {
            Vector3 spawnPosition = GetRandomNavMeshPosition();
            if (spawnPosition != Vector3.zero) //유효한 위치인지 확인
            {
                int randomIndex = Random.Range(0, monsterPrefabs.Length); //랜덤하게 몬스터 선택
                GameObject selectedMonster = monsterPrefabs[randomIndex];
                Instantiate(selectedMonster, spawnPosition, Quaternion.identity);
            }
        }
    }

    private Vector3 GetRandomNavMeshPosition()
    {
        Vector3 randomPosition = Random.insideUnitSphere * spawnRadius;
        randomPosition.y = 0; //y 좌표를 0으로 설정하여 바닥에 위치하도록

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPosition, out hit, spawnRadius, NavMesh.AllAreas))
        {
            //hit.position의 y 값을 사용하여 몬스터가 정확한 높이에 생성되도록 함
            return new Vector3(hit.position.x, hit.position.y, hit.position.z);
        }

        return Vector3.zero; //유효한 NavMesh 위치가 없으면 Vector3.zero 반환
    }
}
