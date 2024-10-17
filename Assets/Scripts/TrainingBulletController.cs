using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingBulletController : MonoBehaviour
{

    private void Update()
    {
        Invoke("DestroyBullet", 1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject); //Enemy�� ������ �ٷ� ����
        }          
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
