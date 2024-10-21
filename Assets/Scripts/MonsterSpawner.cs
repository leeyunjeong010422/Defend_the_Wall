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
            if (spawnPosition != Vector3.zero) //��ȿ�� ��ġ���� Ȯ��
            {
                int randomIndex = Random.Range(0, monsterPrefabs.Length); //�����ϰ� ���� ����
                GameObject selectedMonster = monsterPrefabs[randomIndex];
                Instantiate(selectedMonster, spawnPosition, Quaternion.identity);
            }
        }
    }

    private Vector3 GetRandomNavMeshPosition()
    {
        Vector3 randomPosition = Random.insideUnitSphere * spawnRadius;
        randomPosition.y = 0; //y ��ǥ�� 0���� �����Ͽ� �ٴڿ� ��ġ�ϵ���

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPosition, out hit, spawnRadius, NavMesh.AllAreas))
        {
            //hit.position�� y ���� ����Ͽ� ���Ͱ� ��Ȯ�� ���̿� �����ǵ��� ��
            return new Vector3(hit.position.x, hit.position.y, hit.position.z);
        }

        return Vector3.zero; //��ȿ�� NavMesh ��ġ�� ������ Vector3.zero ��ȯ
    }
}
