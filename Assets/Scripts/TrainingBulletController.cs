using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingBulletController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject); //어떤 오브젝트와 닿아도 총알 제거
    }
}
