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
            GameObject xrOrigin = GameObject.Find("XR Origin");
            if (xrOrigin != null)
            {
                Vector3 xrOriginPosition = xrOrigin.transform.position;

                //XR Origin의 뒤쪽 영역에서 생성되지 않게 설정
                if (hit.position.z > xrOriginPosition.z)
                {
                    //XR Origin 뒤쪽이면 제외하고 다른 위치를 찾도록 0 반환
                    return Vector3.zero;
                }

                //XR Origin에서 최소 40미터 이상 떨어진 위치인지 확인
                float distanceToXROrigin = Vector3.Distance(hit.position, xrOriginPosition);
                if (distanceToXROrigin < 40f)
                {
                    //40미터 이내라면 제외하고 다른 위치를 찾도록 0 반환
                    return Vector3.zero;
                }
            }

            return hit.position;
        }

        return Vector3.zero;
    }
}
