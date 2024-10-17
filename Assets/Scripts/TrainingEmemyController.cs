using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingEmemyController : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject); //�Ѿ� ����
            Destroy(gameObject); //�� ����
        }
    }
}
