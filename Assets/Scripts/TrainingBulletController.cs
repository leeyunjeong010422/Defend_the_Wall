using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingBulletController : MonoBehaviour
{
    private TrainingBulletPool bulletPool;
    private bool isReturning = false; //�߰��߰� �Ѿ��� ������� �ߺ� ȣ�� ���� �ذ�

    private void Start()
    {
        bulletPool = FindObjectOfType<TrainingBulletPool>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && !isReturning)
        {
            isReturning = true;
            bulletPool.ReturnBullet(gameObject); //Enemy�� ������ Ǯ�� ���ư���
        }
    }

    private void OnEnable()
    {
        isReturning = false; //Ȱ��ȭ�� �� �ʱ�ȭ
    }
}
