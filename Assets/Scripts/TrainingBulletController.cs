using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingBulletController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject); //� ������Ʈ�� ��Ƶ� �Ѿ� ����
    }
}
