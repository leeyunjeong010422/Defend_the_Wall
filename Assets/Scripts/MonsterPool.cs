using System.Collections.Generic;
using UnityEngine;

public class MonsterPool : MonoBehaviour
{
    [SerializeField] private GameObject[] monsterPrefabs;
    [SerializeField] private int poolSize = 20;

    private Queue<GameObject> monsterPool = new Queue<GameObject>();

    private void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            int randomIndex = Random.Range(0, monsterPrefabs.Length);
            GameObject monster = Instantiate(monsterPrefabs[randomIndex]);
            monster.SetActive(false);
            monsterPool.Enqueue(monster);
        }
    }

    public GameObject GetMonster()
    {
        if (monsterPool.Count > 0)
        {
            GameObject monster = monsterPool.Dequeue();
            monster.SetActive(true);
            return monster;
        }
        return null;
    }

    public void ReturnMonster(GameObject monster)
    {
        monster.SetActive(false);
        monsterPool.Enqueue(monster);
    }
}
